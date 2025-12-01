using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Domain.Entities;
using Tiroksin.Domain.Enums;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Application.GameSessions.Commands.SubmitAnswer;

public class SubmitAnswerCommandHandler : IRequestHandler<SubmitAnswerCommand, SubmitAnswerResponse>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public SubmitAnswerCommandHandler(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<SubmitAnswerResponse> Handle(SubmitAnswerCommand request, CancellationToken cancellationToken)
    {
        // 1. Get game session
        var gameSession = await _context.GameSessions
            .FirstOrDefaultAsync(gs => gs.Id == request.GameSessionId, cancellationToken);

        if (gameSession == null)
        {
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

        // 2. Get player
        var player = await _context.GameSessionPlayers
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

        bool isCorrect = request.SelectedOptionId.HasValue && request.SelectedOptionId.Value == correctOption.Id;
        bool isTimeout = request.TimeSpent >= 60;
        int pointsEarned = isCorrect ? question.Points : 0;
        bool isEliminated = !isCorrect; // Wrong answer = eliminated

        // 5. Save answer to DB
        var gameAnswer = new GameAnswer
        {
            Id = Guid.NewGuid(),
            GameSessionId = request.GameSessionId,
            UserId = request.UserId,
            QuestionId = request.QuestionId,
            SelectedOptionId = request.SelectedOptionId,
            IsCorrect = isCorrect,
            TimeSpent = request.TimeSpent,
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

        // 7. Get username for notifications
        var user = await _context.Users.FindAsync(new object[] { request.UserId }, cancellationToken);
        var username = user?.Username ?? "Unknown";

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
        var allPlayers = await _context.GameSessionPlayers
            .Where(p => p.GameSessionId == request.GameSessionId)
            .ToListAsync(cancellationToken);

        var answersForThisQuestion = await _context.GameAnswers
            .Where(a => a.GameSessionId == request.GameSessionId && a.QuestionId == request.QuestionId)
            .Select(a => a.UserId)
            .ToListAsync(cancellationToken);

        // Count players who still need to answer:
        // - Players who were NOT eliminated before this question started
        // - This includes players who just got eliminated THIS round (they already submitted their answer)
        // We check: players who were eliminated at a question index BEFORE current, should not be counted
        var currentQuestionIndex = gameSession.CurrentQuestionIndex;
        int activePlayersCount = allPlayers.Count(p =>
            !p.IsEliminated || // Not eliminated
            (p.IsEliminated && p.EliminatedAtQuestionIndex == currentQuestionIndex)); // Or eliminated THIS round

        bool allPlayersAnswered = answersForThisQuestion.Count >= activePlayersCount;

        Console.WriteLine($"📊 Answer check: {answersForThisQuestion.Count}/{activePlayersCount} active players answered (total: {allPlayers.Count})");

        // 10. If all players answered, handle game progression
        if (allPlayersAnswered)
        {
            // Remaining players = those not eliminated
            var remainingPlayers = allPlayers.Count(p => !p.IsEliminated);
            Console.WriteLine($"🎯 All answered! Remaining players: {remainingPlayers}");

            if (remainingPlayers <= 1)
            {
                // Game finished - either one winner or everyone eliminated
                gameSession.Status = RoomStatus.Finished;
                gameSession.FinishedAt = DateTime.UtcNow;

                if (remainingPlayers == 1)
                {
                    var winner = allPlayers.First(p => !p.IsEliminated);
                    winner.IsWinner = true;
                    winner.Rank = 1;
                    Console.WriteLine($"🏆 Winner: {winner.UserId}");
                }
                else
                {
                    // Everyone eliminated - no winner
                    Console.WriteLine($"💀 Everyone eliminated! No winner.");
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
                Console.WriteLine($"⏭️ Moving to next question...");
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
