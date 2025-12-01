using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Api.Hubs;

/// <summary>
/// SignalR Hub for real-time multiplayer game functionality
/// </summary>
// TODO: Production'da [Authorize] aktif edilmeli!
// [Authorize]
public class GameHub : Hub
{
    private readonly ApplicationDbContext _context;

    public GameHub(ApplicationDbContext context)
    {
        _context = context;
    }

    // Active connections: userId -> connectionId
    private static readonly ConcurrentDictionary<string, string> _connections = new();

    // Room connections: roomId -> List<connectionId>
    private static readonly ConcurrentDictionary<string, List<string>> _roomConnections = new();

    public override async Task OnConnectedAsync()
    {
        var userId = Context.UserIdentifier; // JWT'den gelen userId
        var connectionId = Context.ConnectionId;

        if (!string.IsNullOrEmpty(userId))
        {
            _connections[userId] = connectionId;
            Console.WriteLine($"✅ User {userId} connected: {connectionId}");
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.UserIdentifier;
        var connectionId = Context.ConnectionId;

        if (!string.IsNullOrEmpty(userId))
        {
            _connections.TryRemove(userId, out _);
            Console.WriteLine($"❌ User {userId} disconnected: {connectionId}");

            // Remove from all rooms
            foreach (var room in _roomConnections)
            {
                room.Value.Remove(connectionId);
                if (room.Value.Count == 0)
                {
                    _roomConnections.TryRemove(room.Key, out _);
                }
            }
        }

        await base.OnDisconnectedAsync(exception);
    }

    // ============================================
    // ROOM MANAGEMENT
    // ============================================

    /// <summary>
    /// Join a room
    /// </summary>
    public async Task JoinRoom(string roomId, string username, string avatar)
    {
        Console.WriteLine($"🔵 JoinRoom called: roomId={roomId}, username={username}, connectionId={Context.ConnectionId}");

        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        Console.WriteLine($"✅ Added {username} to SignalR group: {roomId}");

        // Track connection
        if (!_roomConnections.ContainsKey(roomId))
        {
            _roomConnections[roomId] = new List<string>();
        }
        _roomConnections[roomId].Add(Context.ConnectionId);
        Console.WriteLine($"📊 _roomConnections for {roomId}: {_roomConnections[roomId].Count} connections");

        // Get userId from JWT token
        var userId = Context.UserIdentifier;

        // Get existing players from database
        var roomGuid = Guid.Parse(roomId);
        var existingPlayers = await _context.RoomPlayers
            .Where(rp => rp.RoomId == roomGuid && rp.LeftAt == null)
            .Include(rp => rp.User)
            .Select(rp => new
            {
                userId = rp.User.Id,
                username = rp.User.Username,
                avatar = rp.User.Avatar ?? "👤",
                isReady = rp.IsReady
            })
            .ToListAsync();

        Console.WriteLine($"📋 Sending {existingPlayers.Count} existing players to {username}");
        foreach (var p in existingPlayers)
        {
            Console.WriteLine($"   - {p.username} ({p.avatar}) Ready: {p.isReady}");
        }

        // Send existing players list to the newly joined player
        await Clients.Caller.SendAsync("RoomPlayersInitialized", new
        {
            players = existingPlayers
        });

        // Log room connections before sending
        var connectionCount = _roomConnections.ContainsKey(roomId) ? _roomConnections[roomId].Count : 0;
        Console.WriteLine($"📡 Sending PlayerJoined to {connectionCount} connections in room {roomId}");

        // Notify all OTHER players in room about new player
        await Clients.OthersInGroup(roomId).SendAsync("PlayerJoined", new
        {
            userId,
            username,
            avatar,
            message = $"{username} odaya katıldı! 🎮"
        });

        Console.WriteLine($"🚪 {username} joined room: {roomId} (total connections: {connectionCount})");
    }

    /// <summary>
    /// Leave a room
    /// </summary>
    public async Task LeaveRoom(string roomId, string username)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);

        // Remove from tracking
        if (_roomConnections.ContainsKey(roomId))
        {
            _roomConnections[roomId].Remove(Context.ConnectionId);
            if (_roomConnections[roomId].Count == 0)
            {
                _roomConnections.TryRemove(roomId, out _);
            }
        }

        // Update database - mark player as left
        try
        {
            var roomGuid = Guid.Parse(roomId);
            var roomPlayer = await _context.RoomPlayers
                .Include(rp => rp.User)
                .FirstOrDefaultAsync(rp => rp.RoomId == roomGuid && rp.User.Username == username && rp.LeftAt == null);

            if (roomPlayer != null)
            {
                roomPlayer.LeftAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                Console.WriteLine($"💾 Database updated: {username} left room");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error updating database for leave room: {ex.Message}");
        }

        // Notify all players in room
        await Clients.Group(roomId).SendAsync("PlayerLeft", new
        {
            username,
            message = $"{username} odadan ayrıldı 👋"
        });

        Console.WriteLine($"🚪 {username} left room: {roomId}");
    }

    /// <summary>
    /// Player marks themselves as ready
    /// </summary>
    public async Task PlayerReady(string roomId, string username, bool isReady)
    {
        // Update database
        var roomGuid = Guid.Parse(roomId);
        var roomPlayer = await _context.RoomPlayers
            .Include(rp => rp.User)
            .FirstOrDefaultAsync(rp => rp.RoomId == roomGuid && rp.User.Username == username && rp.LeftAt == null);

        if (roomPlayer != null)
        {
            roomPlayer.IsReady = isReady;
            await _context.SaveChangesAsync();
            Console.WriteLine($"💾 Database updated: {username} ready status = {isReady}");
        }

        // Notify all players in room
        await Clients.Group(roomId).SendAsync("PlayerReadyStatusChanged", new
        {
            username,
            isReady,
            message = isReady ? $"{username} hazır! ✅" : $"{username} hazır değil ⏳"
        });

        Console.WriteLine($"⏱️ {username} ready status: {isReady}");
    }

    // ============================================
    // UTILITY METHODS
    // ============================================

    /// <summary>
    /// Get active users in a room
    /// </summary>
    public static int GetRoomPlayerCount(string roomId)
    {
        return _roomConnections.ContainsKey(roomId) ? _roomConnections[roomId].Count : 0;
    }

    /// <summary>
    /// Check if user is online
    /// </summary>
    public static bool IsUserOnline(string userId)
    {
        return _connections.ContainsKey(userId);
    }
}
