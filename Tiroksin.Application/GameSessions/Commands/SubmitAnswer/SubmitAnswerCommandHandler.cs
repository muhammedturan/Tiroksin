using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Domain.Entities;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Application.GameSessions.Commands.SubmitAnswer;

public class SubmitAnswerCommandHandler : IRequestHandler<SubmitAnswerCommand, SubmitAnswerResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;
    private readonly ILogger<SubmitAnswerCommandHandler> _logger;

    public SubmitAnswerCommandHandler(IApplicationDbContext context, IMediator mediator, ILogger<SubmitAnswerCommandHandler> logger)
    {
        _context = context;
        _mediator = mediator;
        _logger = logger;
    }

    public async Task<SubmitAnswerResponse> Handle(SubmitAnswerCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Answer submission started: User={UserId}, Session={SessionId}, Question={QuestionId}",
            request.UserId, request.GameSessionId, request.QuestionId);

        // 1. Get game session
        var gameSession = await _context.GameSessions
            .FirstOrDefaultAsync(gs => gs.Id == request.GameSessionId, cancellationToken);

        if (gameSession == null)
        {
            _logger.LogWarning("Answer rejected: Game session not found. Session={SessionId}", request.GameSessionId);
            return new SubmitAnswerResponse { Success = false, Message = "Oyun oturumu bulunamadı" };
        }

        if (gameSession.Status != RoomStatus.InProgress)
        {
            return new SubmitAnswerResponse { Success = false, Message = "Oyun bitti veya henüz başlamadı" };
        }

        // Validate that this is the current question
        if (gameSession.CurrentQuestionId != request.QuestionId)
        {
            return new SubmitAnswerResponse { Success = false, Message = "Bu soru aktif değil" };
        }

        // 2. Get player with user info (avoids separate query for username)
        var player = await _context.GameSessionPlayers
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.GameSessionId == request.GameSessionId && p.UserId == request.UserId, cancellationToken);

        if (player == null)
        {
            return new SubmitAnswerResponse { Success = false, Message = "Oyuncu bulunamadı" };
        }

        if (player.IsEliminated)
        {
            return new SubmitAnswerResponse { Success = false, Message = "Elenmiş oyuncular cevap veremez" };
        }

        // 3. Check if already answered
        var existingAnswer = await _context.GameAnswers
            .FirstOrDefaultAsync(a => a.GameSessionId == request.GameSessionId && a.UserId == request.UserId && a.QuestionId == request.QuestionId, cancellationToken);

        if (existingAnswer != null)
        {
            return new SubmitAnswerResponse { Success = false, Message = "Bu soruyu zaten cevapladınız" };
        }

        // 4. Get question and check answer
        var question = await _context.Questions
            .Include(q => q.Options)
            .FirstOrDefaultAsync(q => q.Id == request.QuestionId, cancellationToken);

        if (question == null)
        {
            return new SubmitAnswerResponse { Success = false, Message = "Soru bulunamadı" };
        }

        var correctOption = question.Options.FirstOrDefault(o => o.IsCorrect);
        if (correctOption == null)
        {
            return new SubmitAnswerResponse { Success = false, Message = "Soru hatalı" };
        }

        // Calculate timeSpent from backend (more secure than client-provided value)
        int timeSpent;
        if (gameSession.QuestionStartedAt.HasValue)
        {
            timeSpent = (int)(DateTime.UtcNow - gameSession.QuestionStartedAt.Value).TotalSeconds;
            // Cap at question timeout (default 60 seconds)
            const int defaultQuestionTimeout = 60;
            timeSpent = Math.Min(timeSpent, defaultQuestionTimeout);
        }
        else
        {
            // Fallback to client value if QuestionStartedAt not set (shouldn't happen)
            timeSpent = Math.Max(0, Math.Min(request.TimeSpent, 60));
        }

        bool isCorrect = request.SelectedOptionId.HasValue && request.SelectedOptionId.Value == correctOption.Id;
        bool isTimeout = timeSpent >= 60 || !request.SelectedOptionId.HasValue;

        // Speed-based scoring system:
        // Base points: Question's own point value (question.Points)
        // Speed bonus: Up to 100% of base points based on remaining time
        // Formula: basePoints + (remainingTime / totalTime) * basePoints
        // Example: 10pt question answered in 10sec (out of 60) = 10 + (50/60 * 10) = ~18 points
        // Fast answer = up to 2x points, slow answer = base points only
        int pointsEarned = 0;
        if (isCorrect)
        {
            int basePoints = question.Points;
            const int questionTimeout = 60;

            int remainingTime = Math.Max(0, questionTimeout - timeSpent);
            double speedMultiplier = (double)remainingTime / questionTimeout;
            int speedBonus = (int)Math.Round(speedMultiplier * basePoints);

            pointsEarned = basePoints + speedBonus;
        }

        bool isEliminated = !isCorrect; // Wrong answer = eliminated

        // Log answer evaluation details
        _logger.LogInformation(
            "Answer evaluated: User={UserId}, Correct={IsCorrect}, TimeSpent={TimeSpent}s, Points={Points}, " +
            "BasePoints={BasePoints}, SpeedBonus={SpeedBonus}, Eliminated={Eliminated}",
            request.UserId, isCorrect, timeSpent, pointsEarned,
            isCorrect ? question.Points : 0,
            isCorrect ? pointsEarned - question.Points : 0,
            isEliminated);

        // 5. Save answer to DB
        var gameAnswer = new GameAnswer
        {
            Id = Guid.NewGuid(),
            GameSessionId = request.GameSessionId,
            UserId = request.UserId,
            QuestionId = request.QuestionId,
            SelectedOptionId = request.SelectedOptionId,
            IsCorrect = isCorrect,
            TimeSpent = timeSpent, // Use backend-calculated timeSpent
            IsTimeout = isTimeout,
            AnsweredAt = DateTime.UtcNow
        };
        _context.GameAnswers.Add(gameAnswer);

        // 6. Update player stats
        player.Score += pointsEarned;
        if (isCorrect) player.CorrectAnswers++;
        else if (request.SelectedOptionId.HasValue) player.WrongAnswers++;
        if (isTimeout) player.TimeoutCount++;

        if (isEliminated)
        {
            player.IsEliminated = true;
            player.EliminatedAtQuestionIndex = gameSession.CurrentQuestionIndex;
        }

        await _context.SaveChangesAsync(cancellationToken);

        // 7. Get username for notifications (already loaded via Include)
        var username = player.User?.Username ?? "Unknown";

        // 8. Publish PlayerEliminated if eliminated
        if (isEliminated)
        {
            await _mediator.Publish(new PlayerEliminatedNotification
            {
                GameSessionId = gameSession.Id,
                RoomId = gameSession.RoomId,
                UserId = request.UserId,
                Username = username
            }, cancellationToken);
        }

        // 9. Check if all active players have answered this question
        // Use a single atomic query to prevent race conditions
        var currentQuestionIndex = gameSession.CurrentQuestionIndex;

        // Get counts in a single query to minimize race window
        var playerCounts = await _context.GameSessionPlayers
            .Where(p => p.GameSessionId == request.GameSessionId)
            .GroupBy(p => 1) // Group all into one
            .Select(g => new
            {
                TotalPlayers = g.Count(),
                // Players who should answer this round (not eliminated before this question)
                ActivePlayers = g.Count(p => !p.IsEliminated || p.EliminatedAtQuestionIndex == currentQuestionIndex),
                RemainingPlayers = g.Count(p => !p.IsEliminated)
            })
            .FirstOrDefaultAsync(cancellationToken);

        var answerCount = await _context.GameAnswers
            .CountAsync(a => a.GameSessionId == request.GameSessionId && a.QuestionId == request.QuestionId, cancellationToken);

        int activePlayersCount = playerCounts?.ActivePlayers ?? 0;
        int remainingPlayersCount = playerCounts?.RemainingPlayers ?? 0;
        bool allPlayersAnswered = answerCount >= activePlayersCount;

        _logger.LogDebug("Answer check: {Answered}/{ActivePlayers} active players answered (total: {TotalPlayers})",
            answerCount, activePlayersCount, playerCounts?.TotalPlayers ?? 0);

        // 10. If all players answered, handle game progression
        if (allPlayersAnswered)
        {
            _logger.LogDebug("All answered! Remaining players: {RemainingPlayers}", remainingPlayersCount);

            if (remainingPlayersCount <= 1)
            {
                // Game finished - either one winner or everyone eliminated
                gameSession.Status = RoomStatus.Finished;
                gameSession.FinishedAt = DateTime.UtcNow;

                // Fetch all players for ranking (only needed when game ends)
                var allPlayersForRanking = await _context.GameSessionPlayers
                    .Where(p => p.GameSessionId == request.GameSessionId)
                    .ToListAsync(cancellationToken);

                // Calculate rankings for ALL players based on score
                var rankedPlayers = allPlayersForRanking
                    .OrderByDescending(p => p.Score)
                    .ThenBy(p => p.IsEliminated) // Non-eliminated first
                    .ThenBy(p => p.EliminatedAtQuestionIndex ?? int.MaxValue) // Later elimination = better
                    .ToList();

                for (int i = 0; i < rankedPlayers.Count; i++)
                {
                    rankedPlayers[i].Rank = i + 1;
                    rankedPlayers[i].IsWinner = i == 0 && !rankedPlayers[i].IsEliminated;
                }

                if (remainingPlayersCount == 1)
                {
                    var winner = rankedPlayers.FirstOrDefault(p => p.IsWinner);
                    if (winner != null)
                    {
                        _logger.LogInformation("Game winner determined: {WinnerId}", winner.UserId);
                    }
                }
                else
                {
                    // Everyone eliminated - no winner, but still ranked by score
                    _logger.LogInformation("Game ended with no winner - all players eliminated");
                }

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new GameFinishedNotification
                {
                    GameSessionId = gameSession.Id,
                    RoomId = gameSession.RoomId
                }, cancellationToken);
            }
            else
            {
                // Move to next question
                _logger.LogDebug("Moving to next question for GameSession: {GameSessionId}", gameSession.Id);
                await _mediator.Publish(new AllPlayersAnsweredNotification
                {
                    GameSessionId = gameSession.Id,
                    RoomId = gameSession.RoomId,
                    QuestionId = request.QuestionId
                }, cancellationToken);
            }
        }

        return new SubmitAnswerResponse
        {
            Success = true,
            IsCorrect = isCorrect,
            PointsEarned = pointsEarned,
            CorrectOptionId = correctOption.Id,
            TotalScore = player.Score,
            CorrectAnswers = player.CorrectAnswers,
            WrongAnswers = player.WrongAnswers,
            IsEliminated = isEliminated,
            IsGameFinished = gameSession.Status == RoomStatus.Finished,
            Message = isEliminated
                ? (isTimeout ? "Süre doldu! Elendiniz" : "Yanlış! Elendiniz")
                : (isCorrect ? "Doğru!" : "Yanlış")
        };
    }
}

// Notifications
public record AllPlayersAnsweredNotification : INotification
{
    public Guid GameSessionId { get; init; }
    public Guid RoomId { get; init; }
    public Guid QuestionId { get; init; }
}

public record GameFinishedNotification : INotification
{
    public Guid GameSessionId { get; init; }
    public Guid RoomId { get; init; }
}

public record PlayerEliminatedNotification : INotification
{
    public Guid GameSessionId { get; init; }
    public Guid RoomId { get; init; }
    public Guid UserId { get; init; }
    public string Username { get; init; } = string.Empty;
}
