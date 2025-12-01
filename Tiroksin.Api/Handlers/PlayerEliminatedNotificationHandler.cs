using MediatR;
using Microsoft.AspNetCore.SignalR;
using Tiroksin.Api.Hubs;
using Tiroksin.Application.GameSessions.Commands.SubmitAnswer;

namespace Tiroksin.Api.Handlers;

public class PlayerEliminatedNotificationHandler : INotificationHandler<PlayerEliminatedNotification>
{
    private readonly IHubContext<GameHub> _hubContext;
    private readonly ILogger<PlayerEliminatedNotificationHandler> _logger;

    public PlayerEliminatedNotificationHandler(
        IHubContext<GameHub> hubContext,
        ILogger<PlayerEliminatedNotificationHandler> logger)
    {
        _hubContext = hubContext;
        _logger = logger;
    }

    public async Task Handle(PlayerEliminatedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Player {Username} ({UserId}) eliminated in session {GameSessionId}. Sending PlayerEliminated event to room {RoomId}",
            notification.Username, notification.UserId, notification.GameSessionId, notification.RoomId);

        await _hubContext.Clients.Group(notification.RoomId.ToString())
            .SendAsync("PlayerEliminated", new
            {
                userId = notification.UserId,
                username = notification.Username,
                message = $"{notification.Username} elendi!",
                timestamp = DateTime.UtcNow
            }, cancellationToken);
    }
}
