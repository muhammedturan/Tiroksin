using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tiroksin.Api.Hubs;
using Tiroksin.Api.Settings;
using Tiroksin.Application.GameSessions.Commands.SubmitAnswer;
using Tiroksin.Domain.Enums;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Api.Services;

/// <summary>
/// Background service that handles server-side timeout for players who haven't answered
/// This prevents games from getting stuck when players disconnect
/// </summary>
public class GameTimeoutService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<GameTimeoutService> _logger;
    private readonly GameSettings _gameSettings;
    private readonly RoomSettings _roomSettings;

    public GameTimeoutService(
        IServiceProvider serviceProvider,
        ILogger<GameTimeoutService> logger,
        IOptions<GameSettings> gameSettings,
        IOptions<RoomSettings> roomSettings)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _gameSettings = gameSettings.Value;
        _roomSettings = roomSettings.Value;
    }

    private TimeSpan CheckInterval => TimeSpan.FromSeconds(_roomSettings.TimeoutCheckIntervalSeconds);
    private int QuestionTimeoutSeconds => _gameSettings.QuestionTimeoutSeconds + _gameSettings.TimeoutBufferSeconds;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Game Timeout Service started");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await CheckAndProcessTimeoutsAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during game timeout check");
            }

            await Task.Delay(CheckInterval, stoppingToken);
        }

        _logger.LogInformation("Game Timeout Service stopped");
    }

    private async Task CheckAndProcessTimeoutsAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<GameHub>>();

        var now = DateTime.UtcNow;
        var timeoutThreshold = now.AddSeconds(-QuestionTimeoutSeconds);

        // Find active game sessions where question has timed out
        var timedOutSessions = await context.GameSessions
            .Include(gs => gs.Room)
            .Where(gs => gs.Status == RoomStatus.InProgress &&
                        gs.QuestionStartedAt != null &&
                        gs.QuestionStartedAt <= timeoutThreshold)
            .ToListAsync(cancellationToken);

        foreach (var session in timedOutSessions)
        {
            try
            {
                await ProcessSessionTimeoutAsync(context, hubContext, session, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing timeout for session {SessionId}", session.Id);
            }
        }
    }

    private async Task ProcessSessionTimeoutAsync(
        ApplicationDbContext context,
        IHubContext<GameHub> hubContext,
        Domain.Entities.GameSession session,
        CancellationToken cancellationToken)
    {
        // Get players who need to answer this question
        var allPlayers = await context.GameSessionPlayers
            .Where(p => p.GameSessionId == session.Id)
            .Include(p => p.User)
            .ToListAsync(cancellationToken);

        // Get answers already submitted for current question
        var answeredUserIds = await context.GameAnswers
            .Where(a => a.GameSessionId == session.Id && a.QuestionId == session.CurrentQuestionId)
            .Select(a => a.UserId)
            .ToListAsync(cancellationToken);

        // Find players who should have answered but didn't (active this round)
        var currentQuestionIndex = session.CurrentQuestionIndex;
        var playersWhoShouldAnswer = allPlayers.Where(p =>
            (!p.IsEliminated || p.EliminatedAtQuestionIndex == currentQuestionIndex) &&
            !answeredUserIds.Contains(p.UserId)).ToList();

        if (playersWhoShouldAnswer.Count == 0)
        {
            // Everyone answered, but AllPlayersAnswered wasn't triggered - force it
            _logger.LogWarning("Session {SessionId} timed out but all players answered - triggering progression",
                session.Id);
            return;
        }

        _logger.LogInformation("Processing timeout for {Count} players in session {SessionId}",
            playersWhoShouldAnswer.Count, session.Id);

        // Force timeout answers for each player who didn't answer
        foreach (var player in playersWhoShouldAnswer)
        {
            // Create timeout answer
            var timeoutAnswer = new Domain.Entities.GameAnswer
            {
                Id = Guid.NewGuid(),
                GameSessionId = session.Id,
                UserId = player.UserId,
                QuestionId = session.CurrentQuestionId!.Value,
                SelectedOptionId = null, // No answer selected
                IsCorrect = false,
                TimeSpent = QuestionTimeoutSeconds,
                IsTimeout = true,
                AnsweredAt = DateTime.UtcNow
            };
            context.GameAnswers.Add(timeoutAnswer);

            // Update player stats
            player.TimeoutCount++;
            player.IsEliminated = true;
            player.EliminatedAtQuestionIndex = currentQuestionIndex;

            _logger.LogInformation("Player {Username} ({UserId}) timed out and eliminated in session {SessionId}",
                player.User?.Username ?? "Unknown", player.UserId, session.Id);

            // Send PlayerEliminated event
            await hubContext.Clients.Group(session.RoomId.ToString())
                .SendAsync("PlayerEliminated", new
                {
                    userId = player.UserId,
                    username = player.User?.Username ?? "Unknown",
                    reason = "Timeout"
                }, cancellationToken);
        }

        await context.SaveChangesAsync(cancellationToken);

        // Now check if we need to progress the game
        await CheckAndProgressGameAsync(context, hubContext, session, allPlayers, cancellationToken);
    }

    private async Task CheckAndProgressGameAsync(
        ApplicationDbContext context,
        IHubContext<GameHub> hubContext,
        Domain.Entities.GameSession session,
        List<Domain.Entities.GameSessionPlayer> allPlayers,
        CancellationToken cancellationToken)
    {
        // Reload players to get updated elimination status
        var updatedPlayers = await context.GameSessionPlayers
            .Where(p => p.GameSessionId == session.Id)
            .Include(p => p.User)
            .ToListAsync(cancellationToken);

        var remainingPlayers = updatedPlayers.Count(p => !p.IsEliminated);

        _logger.LogInformation("After timeout processing: {Remaining} players remaining in session {SessionId}",
            remainingPlayers, session.Id);

        if (remainingPlayers <= 1)
        {
            // Game finished
            await FinishGameAsync(context, hubContext, session, updatedPlayers, cancellationToken);
        }
        else
        {
            // Move to next question
            await MoveToNextQuestionAsync(context, hubContext, session, updatedPlayers, cancellationToken);
        }
    }

    private async Task FinishGameAsync(
        ApplicationDbContext context,
        IHubContext<GameHub> hubContext,
        Domain.Entities.GameSession session,
        List<Domain.Entities.GameSessionPlayer> players,
        CancellationToken cancellationToken)
    {
        session.Status = RoomStatus.Finished;
        session.FinishedAt = DateTime.UtcNow;

        // Calculate rankings
        var rankedPlayers = players
            .OrderByDescending(p => p.Score)
            .ThenBy(p => p.IsEliminated)
            .ThenBy(p => p.EliminatedAtQuestionIndex ?? int.MaxValue)
            .ToList();

        for (int i = 0; i < rankedPlayers.Count; i++)
        {
            rankedPlayers[i].Rank = i + 1;
            rankedPlayers[i].IsWinner = i == 0 && !rankedPlayers[i].IsEliminated;
        }

        await context.SaveChangesAsync(cancellationToken);

        // Send GameFinished event
        await hubContext.Clients.Group(session.RoomId.ToString())
            .SendAsync("GameFinished", new
            {
                gameSessionId = session.Id,
                roomId = session.RoomId,
                reason = "GameComplete"
            }, cancellationToken);

        _logger.LogInformation("Game {SessionId} finished via timeout service", session.Id);
    }

    private async Task MoveToNextQuestionAsync(
        ApplicationDbContext context,
        IHubContext<GameHub> hubContext,
        Domain.Entities.GameSession session,
        List<Domain.Entities.GameSessionPlayer> players,
        CancellationToken cancellationToken)
    {
        // Get already asked questions
        var askedQuestionIds = await context.GameAnswers
            .Where(a => a.GameSessionId == session.Id)
            .Select(a => a.QuestionId)
            .Distinct()
            .ToListAsync(cancellationToken);

        // Find next available question
        var nextQuestion = await context.Questions
            .Include(q => q.Options)
            .Where(q => q.Status == QuestionStatus.Approved && !askedQuestionIds.Contains(q.Id))
            .OrderBy(q => Guid.NewGuid()) // Random order
            .FirstOrDefaultAsync(cancellationToken);

        if (nextQuestion == null)
        {
            // No more questions - finish game
            _logger.LogInformation("No more questions available for session {SessionId} - finishing game", session.Id);
            await FinishGameAsync(context, hubContext, session, players, cancellationToken);
            return;
        }

        // Update game session
        int nextQuestionIndex = session.CurrentQuestionIndex + 1;
        session.CurrentQuestionIndex = nextQuestionIndex;
        session.CurrentQuestionId = nextQuestion.Id;
        session.QuestionStartedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        // Prepare player statuses
        var playerStatuses = players.Select(p => new
        {
            userId = p.UserId,
            username = p.User?.Username ?? "Unknown",
            isEliminated = p.IsEliminated,
            score = p.Score,
            correctAnswers = p.CorrectAnswers,
            wrongAnswers = p.WrongAnswers
        }).ToList();

        // Shuffle options
        var shuffledOptions = nextQuestion.Options.ToList();
        ShuffleList(shuffledOptions);

        var questionDto = new
        {
            id = nextQuestion.Id,
            text = nextQuestion.Text,
            imageUrl = nextQuestion.ImageUrl,
            points = nextQuestion.Points,
            options = shuffledOptions.Select((o, index) => new
            {
                id = o.Id,
                optionKey = ((char)('A' + index)).ToString(),
                text = o.Text,
                imageUrl = o.ImageUrl
            }).ToList()
        };

        // Send NextQuestion event
        await hubContext.Clients.Group(session.RoomId.ToString())
            .SendAsync("NextQuestion", new
            {
                questionIndex = nextQuestionIndex,
                question = questionDto,
                players = playerStatuses,
                timeLimit = 60,
                timestamp = DateTime.UtcNow
            }, cancellationToken);

        _logger.LogInformation("Moved session {SessionId} to question {QuestionIndex} via timeout service",
            session.Id, nextQuestionIndex);
    }

    private static void ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}
