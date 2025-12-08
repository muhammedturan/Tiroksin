using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tiroksin.Api.Settings;
using Tiroksin.Domain.Enums;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Api.Services;

/// <summary>
/// Background service that periodically cleans up expired and empty rooms
/// </summary>
public class RoomCleanupService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RoomCleanupService> _logger;
    private readonly RoomSettings _roomSettings;

    public RoomCleanupService(
        IServiceProvider serviceProvider,
        ILogger<RoomCleanupService> logger,
        IOptions<RoomSettings> roomSettings)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _roomSettings = roomSettings.Value;
    }

    private TimeSpan CheckInterval => TimeSpan.FromMinutes(_roomSettings.CleanupIntervalMinutes);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Room Cleanup Service started (interval: {Minutes} minutes)", _roomSettings.CleanupIntervalMinutes);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await CleanupExpiredRoomsAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during room cleanup");
            }

            await Task.Delay(CheckInterval, stoppingToken);
        }

        _logger.LogInformation("Room Cleanup Service stopped");
    }

    private async Task CleanupExpiredRoomsAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var now = DateTime.UtcNow;

        // Find rooms that are expired or have no active players
        var roomsToClose = await context.Rooms
            .Include(r => r.Players)
            .Where(r => r.Status == RoomStatus.Waiting &&
                       (r.ExpiresAt <= now || !r.Players.Any(p => p.LeftAt == null)))
            .ToListAsync(cancellationToken);

        if (roomsToClose.Count > 0)
        {
            foreach (var room in roomsToClose)
            {
                room.Status = RoomStatus.Cancelled;
                room.FinishedAt = now;
            }

            await context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Cleaned up {Count} expired/empty rooms", roomsToClose.Count);
        }
    }
}
