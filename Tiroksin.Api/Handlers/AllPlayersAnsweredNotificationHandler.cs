using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Api.Hubs;
using Tiroksin.Application.GameSessions.Commands.SubmitAnswer;
using Tiroksin.Domain.Enums;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Api.Handlers;

public class AllPlayersAnsweredNotificationHandler : INotificationHandler<AllPlayersAnsweredNotification>
{
    private readonly IHubContext<GameHub> _hubContext;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AllPlayersAnsweredNotificationHandler> _logger;

    public AllPlayersAnsweredNotificationHandler(
        IHubContext<GameHub> hubContext,
        ApplicationDbContext context,
        ILogger<AllPlayersAnsweredNotificationHandler> logger)
    {
        _hubContext = hubContext;
        _context = context;
        _logger = logger;
    }

    public async Task Handle(AllPlayersAnsweredNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("All players answered for question {QuestionId}. Session: {GameSessionId}",
            notification.QuestionId, notification.GameSessionId);

        // 1. Get game session
        var gameSession = await _context.GameSessions
            .FirstOrDefaultAsync(gs => gs.Id == notification.GameSessionId, cancellationToken);

        if (gameSession == null)
        {
            _logger.LogError("Game session not found: {GameSessionId}", notification.GameSessionId);
            return;
        }

        // CRITICAL: Verify this notification is for the current question
        // This prevents duplicate NextQuestion events if multiple answers trigger this handler
        if (gameSession.CurrentQuestionId != notification.QuestionId)
        {
            _logger.LogWarning("Ignoring notification for old question. Current: {Current}, Notification: {Notification}",
                gameSession.CurrentQuestionId, notification.QuestionId);
            return;
        }

        // 2. Get already asked question IDs from GameAnswers
        var askedQuestionIds = await _context.GameAnswers
            .Where(a => a.GameSessionId == notification.GameSessionId)
            .Select(a => a.QuestionId)
            .Distinct()
            .ToListAsync(cancellationToken);

        // 3. Select a random question that hasn't been asked yet
        var nextQuestion = await _context.Questions
            .Include(q => q.Options)
            .Where(q => q.Status == QuestionStatus.Approved && !askedQuestionIds.Contains(q.Id))
            .OrderBy(q => Guid.NewGuid())
            .FirstOrDefaultAsync(cancellationToken);

        if (nextQuestion == null)
        {
            _logger.LogWarning("No more questions available - game should finish");
            return;
        }

        // 4. Update game session
        int nextQuestionIndex = gameSession.CurrentQuestionIndex + 1;
        gameSession.CurrentQuestionIndex = nextQuestionIndex;
        gameSession.CurrentQuestionId = nextQuestion.Id;
        gameSession.QuestionStartedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);

        // 5. Get all players with their current status
        var players = await _context.GameSessionPlayers
            .Where(p => p.GameSessionId == notification.GameSessionId)
            .Include(p => p.User)
            .ToListAsync(cancellationToken);

        var playerStatuses = players.Select(p => new
        {
            userId = p.UserId,
            username = p.User?.Username ?? "Unknown",
            isEliminated = p.IsEliminated,
            score = p.Score,
            correctAnswers = p.CorrectAnswers,
            wrongAnswers = p.WrongAnswers
        }).ToList();

        // 6. Prepare question DTO with shuffled options
        var shuffledOptions = nextQuestion.Options.OrderBy(o => Guid.NewGuid()).ToList();
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

        // 7. Send NextQuestion event
        _logger.LogInformation("Sending NextQuestion event. QuestionIndex: {Index}", nextQuestionIndex);

        await _hubContext.Clients.Group(notification.RoomId.ToString())
            .SendAsync("NextQuestion", new
            {
                questionIndex = nextQuestionIndex,
                question = questionDto,
                players = playerStatuses,
                timeLimit = 60,
                timestamp = DateTime.UtcNow
            }, cancellationToken);

        _logger.LogInformation("NextQuestion event sent successfully");
    }
}
