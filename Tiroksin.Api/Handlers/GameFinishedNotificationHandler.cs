using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Api.Hubs;
using Tiroksin.Application.GameSessions.Commands.SubmitAnswer;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Api.Handlers;

public class GameFinishedNotificationHandler : INotificationHandler<GameFinishedNotification>
{
    private readonly IHubContext<GameHub> _hubContext;
    private readonly ILogger<GameFinishedNotificationHandler> _logger;
    private readonly ApplicationDbContext _context;

    public GameFinishedNotificationHandler(
        IHubContext<GameHub> hubContext,
        ILogger<GameFinishedNotificationHandler> logger,
        ApplicationDbContext context)
    {
        _hubContext = hubContext;
        _logger = logger;
        _context = context;
    }

    public async Task Handle(GameFinishedNotification notification, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Game session {GameSessionId} finished. Sending GameFinished event to room {RoomId}",
                notification.GameSessionId, notification.RoomId);

            // Get final results
            var players = await _context.GameSessionPlayers
                .Include(p => p.User)
                .Where(p => p.GameSessionId == notification.GameSessionId)
                .OrderByDescending(p => p.Score)
                .ThenBy(p => p.EliminatedAtQuestionIndex)
                .Select(p => new
                {
                    userId = p.UserId,
                    username = p.User != null ? p.User.Username : "Unknown",
                    avatar = p.User != null ? p.User.Avatar ?? "👤" : "👤",
                    score = p.Score,
                    correctAnswers = p.CorrectAnswers,
                    wrongAnswers = p.WrongAnswers,
                    isWinner = p.IsWinner,
                    rank = p.Rank,
                    isEliminated = p.IsEliminated,
                    eliminatedAtQuestionIndex = p.EliminatedAtQuestionIndex
                })
                .ToListAsync(cancellationToken);

            await _hubContext.Clients.Group(notification.RoomId.ToString())
                .SendAsync("GameFinished", new
                {
                    message = "Oyun bitti!",
                    gameSessionId = notification.GameSessionId,
                    results = players,
                    timestamp = DateTime.UtcNow
                }, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending GameFinished event for session {SessionId}", notification.GameSessionId);

            // Try to at least notify clients
            try
            {
                await _hubContext.Clients.Group(notification.RoomId.ToString())
                    .SendAsync("GameFinished", new
                    {
                        message = "Oyun bitti!",
                        gameSessionId = notification.GameSessionId,
                        results = Array.Empty<object>(),
                        error = "Sonuçlar yüklenirken bir hata oluştu",
                        timestamp = DateTime.UtcNow
                    }, cancellationToken);
            }
            catch (Exception notifyEx)
            {
                _logger.LogError(notifyEx, "Failed to notify clients about game finish error");
            }
        }
    }
}
