using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using Tiroksin.Domain.Enums;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Api.Hubs;

/// <summary>
/// SignalR Hub for real-time multiplayer game functionality
/// </summary>
[Authorize]
public class GameHub : Hub
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<GameHub> _logger;

    public GameHub(ApplicationDbContext context, ILogger<GameHub> logger)
    {
        _context = context;
        _logger = logger;
    }

    // Active connections: userId -> connectionId
    private static readonly ConcurrentDictionary<string, string> _connections = new();

    // Room connections: roomId -> HashSet<connectionId> (thread-safe with lock)
    private static readonly ConcurrentDictionary<string, HashSet<string>> _roomConnections = new();
    private static readonly object _roomLock = new();

    public override async Task OnConnectedAsync()
    {
        var userId = Context.UserIdentifier; // JWT'den gelen userId
        var connectionId = Context.ConnectionId;

        if (!string.IsNullOrEmpty(userId))
        {
            // Check if user already has a connection (reconnection scenario)
            if (_connections.TryGetValue(userId, out var oldConnectionId) && oldConnectionId != connectionId)
            {
                _logger.LogInformation("User {UserId} reconnecting. Replacing old connection {OldConnectionId} with {NewConnectionId}",
                    userId, oldConnectionId, connectionId);

                // Remove old connection from all rooms
                await CleanupStaleConnectionAsync(oldConnectionId);
            }

            _connections[userId] = connectionId;
            _logger.LogInformation("User {UserId} connected with ConnectionId {ConnectionId}", userId, connectionId);
        }

        await base.OnConnectedAsync();
    }

    /// <summary>
    /// Clean up a stale connection from all rooms
    /// </summary>
    private async Task CleanupStaleConnectionAsync(string connectionId)
    {
        var roomsToCleanup = new List<string>();

        lock (_roomLock)
        {
            foreach (var room in _roomConnections)
            {
                if (room.Value.Remove(connectionId))
                {
                    _logger.LogDebug("Removed stale connection {ConnectionId} from room {RoomId}", connectionId, room.Key);
                }
                if (room.Value.Count == 0)
                {
                    roomsToCleanup.Add(room.Key);
                }
            }
            foreach (var roomId in roomsToCleanup)
            {
                _roomConnections.TryRemove(roomId, out _);
            }
        }

        // Also remove from SignalR groups (best effort)
        foreach (var room in _roomConnections.Keys)
        {
            try
            {
                await Groups.RemoveFromGroupAsync(connectionId, room);
            }
            catch
            {
                // Connection might already be gone, ignore
            }
        }
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.UserIdentifier;
        var connectionId = Context.ConnectionId;

        if (!string.IsNullOrEmpty(userId))
        {
            _connections.TryRemove(userId, out _);
            _logger.LogInformation("User {UserId} disconnected with ConnectionId {ConnectionId}", userId, connectionId);

            // Remove from all rooms with proper locking
            var roomsToCleanup = new List<string>();
            lock (_roomLock)
            {
                foreach (var room in _roomConnections)
                {
                    room.Value.Remove(connectionId);
                    if (room.Value.Count == 0)
                    {
                        roomsToCleanup.Add(room.Key);
                    }
                }
                // Remove empty rooms
                foreach (var roomId in roomsToCleanup)
                {
                    _roomConnections.TryRemove(roomId, out _);
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
        // Input validation
        if (!Guid.TryParse(roomId, out var roomGuid))
        {
            await Clients.Caller.SendAsync("Error", new { message = "Geçersiz oda kimliği" });
            return;
        }

        if (string.IsNullOrWhiteSpace(username) || username.Length > 50)
        {
            await Clients.Caller.SendAsync("Error", new { message = "Geçersiz kullanıcı adı" });
            return;
        }

        // Sanitize username to prevent XSS (avatar is emoji-only, no encoding needed)
        username = System.Net.WebUtility.HtmlEncode(username.Trim());
        avatar = string.IsNullOrWhiteSpace(avatar) ? "👤" : avatar.Trim();

        _logger.LogInformation("JoinRoom called: RoomId={RoomId}, Username={Username}, ConnectionId={ConnectionId}",
            roomId, username, Context.ConnectionId);

        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        _logger.LogDebug("Added {Username} to SignalR group {RoomId}", username, roomId);

        // Track connection with thread-safe HashSet
        lock (_roomLock)
        {
            if (!_roomConnections.ContainsKey(roomId))
            {
                _roomConnections[roomId] = new HashSet<string>();
            }
            _roomConnections[roomId].Add(Context.ConnectionId);
        }
        var connectionCount = _roomConnections.TryGetValue(roomId, out var conns) ? conns.Count : 0;
        _logger.LogDebug("Room {RoomId} has {ConnectionCount} connections", roomId, connectionCount);

        // Get userId from JWT token
        var userId = Context.UserIdentifier;

        // Get existing players from database
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

        _logger.LogDebug("Sending {PlayerCount} existing players to {Username}", existingPlayers.Count, username);

        // Send existing players list to the newly joined player
        await Clients.Caller.SendAsync("RoomPlayersInitialized", new
        {
            players = existingPlayers
        });

        _logger.LogDebug("Sending PlayerJoined to {ConnectionCount} connections in room {RoomId}", connectionCount, roomId);

        // Notify all OTHER players in room about new player
        await Clients.OthersInGroup(roomId).SendAsync("PlayerJoined", new
        {
            userId,
            username,
            avatar,
            message = $"{username} odaya katıldı!"
        });

        _logger.LogInformation("User {Username} joined room {RoomId}, total connections: {ConnectionCount}",
            username, roomId, connectionCount);
    }

    /// <summary>
    /// Leave a room
    /// </summary>
    public async Task LeaveRoom(string roomId, string username)
    {
        // Input validation
        if (!Guid.TryParse(roomId, out var roomGuid))
        {
            await Clients.Caller.SendAsync("Error", new { message = "Geçersiz oda kimliği" });
            return;
        }

        if (string.IsNullOrWhiteSpace(username) || username.Length > 50)
        {
            await Clients.Caller.SendAsync("Error", new { message = "Geçersiz kullanıcı adı" });
            return;
        }

        username = System.Net.WebUtility.HtmlEncode(username.Trim());

        await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);

        // Remove from tracking with thread-safety
        lock (_roomLock)
        {
            if (_roomConnections.TryGetValue(roomId, out var connections))
            {
                connections.Remove(Context.ConnectionId);
                if (connections.Count == 0)
                {
                    _roomConnections.TryRemove(roomId, out _);
                }
            }
        }

        // Update database - mark player as left
        try
        {
            var roomPlayer = await _context.RoomPlayers
                .Include(rp => rp.User)
                .FirstOrDefaultAsync(rp => rp.RoomId == roomGuid && rp.User.Username == username && rp.LeftAt == null);

            if (roomPlayer != null)
            {
                roomPlayer.LeftAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogDebug("Database updated: {Username} left room", username);

                // Check if room is now empty (only for Waiting rooms)
                var room = await _context.Rooms
                    .Include(r => r.Players)
                    .FirstOrDefaultAsync(r => r.Id == roomGuid);

                if (room != null && room.Status == RoomStatus.Waiting)
                {
                    var activePlayerCount = room.Players.Count(p => p.LeftAt == null);
                    if (activePlayerCount == 0)
                    {
                        // Close the empty room
                        room.Status = RoomStatus.Cancelled;
                        room.FinishedAt = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        _logger.LogInformation("Room {RoomId} closed automatically - no players remaining", roomId);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error updating database for leave room: {Username}, {RoomId}", username, roomId);
        }

        // Notify all players in room
        await Clients.Group(roomId).SendAsync("PlayerLeft", new
        {
            username,
            message = $"{username} odadan ayrıldı"
        });

        _logger.LogInformation("User {Username} left room {RoomId}", username, roomId);
    }

    /// <summary>
    /// Player marks themselves as ready
    /// </summary>
    public async Task PlayerReady(string roomId, string username, bool isReady)
    {
        // Input validation
        if (!Guid.TryParse(roomId, out var roomGuid))
        {
            await Clients.Caller.SendAsync("Error", new { message = "Geçersiz oda kimliği" });
            return;
        }

        if (string.IsNullOrWhiteSpace(username) || username.Length > 50)
        {
            await Clients.Caller.SendAsync("Error", new { message = "Geçersiz kullanıcı adı" });
            return;
        }

        username = System.Net.WebUtility.HtmlEncode(username.Trim());

        // Update database
        var roomPlayer = await _context.RoomPlayers
            .Include(rp => rp.User)
            .FirstOrDefaultAsync(rp => rp.RoomId == roomGuid && rp.User.Username == username && rp.LeftAt == null);

        if (roomPlayer != null)
        {
            roomPlayer.IsReady = isReady;
            await _context.SaveChangesAsync();
            _logger.LogDebug("Database updated: {Username} ready status = {IsReady}", username, isReady);
        }

        // Notify all players in room
        await Clients.Group(roomId).SendAsync("PlayerReadyStatusChanged", new
        {
            username,
            isReady,
            message = isReady ? $"{username} hazır!" : $"{username} hazır değil"
        });

        _logger.LogInformation("User {Username} ready status changed to {IsReady} in room {RoomId}",
            username, isReady, roomId);
    }

    // ============================================
    // GAME REJOIN
    // ============================================

    /// <summary>
    /// Allows a player to rejoin an active game after disconnection
    /// </summary>
    public async Task RejoinGame(string roomId)
    {
        // Input validation
        if (!Guid.TryParse(roomId, out var roomGuid))
        {
            await Clients.Caller.SendAsync("RejoinFailed", new { message = "Geçersiz oda kimliği" });
            return;
        }

        var userIdStr = Context.UserIdentifier;
        if (string.IsNullOrEmpty(userIdStr) || !Guid.TryParse(userIdStr, out var userId))
        {
            await Clients.Caller.SendAsync("RejoinFailed", new { message = "Kullanıcı kimliği bulunamadı" });
            return;
        }

        _logger.LogInformation("RejoinGame requested: UserId={UserId}, RoomId={RoomId}", userId, roomId);

        // Get the active game session for this room
        var gameSession = await _context.GameSessions
            .Include(gs => gs.Room)
            .FirstOrDefaultAsync(gs => gs.RoomId == roomGuid && gs.Status == RoomStatus.InProgress);

        if (gameSession == null)
        {
            await Clients.Caller.SendAsync("RejoinFailed", new { message = "Aktif oyun bulunamadı" });
            return;
        }

        // Get the player's status in this game
        var player = await _context.GameSessionPlayers
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.GameSessionId == gameSession.Id && p.UserId == userId);

        if (player == null)
        {
            await Clients.Caller.SendAsync("RejoinFailed", new { message = "Bu oyunda oyuncu olarak kayıtlı değilsiniz" });
            return;
        }

        // Add to SignalR group
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);

        // Track connection
        lock (_roomLock)
        {
            if (!_roomConnections.ContainsKey(roomId))
            {
                _roomConnections[roomId] = new HashSet<string>();
            }
            _roomConnections[roomId].Add(Context.ConnectionId);
        }

        // Get current question if exists
        object? currentQuestion = null;
        bool hasAnsweredCurrentQuestion = false;

        if (gameSession.CurrentQuestionId.HasValue)
        {
            var question = await _context.Questions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == gameSession.CurrentQuestionId.Value);

            if (question != null)
            {
                // Check if player already answered this question
                hasAnsweredCurrentQuestion = await _context.GameAnswers
                    .AnyAsync(a => a.GameSessionId == gameSession.Id &&
                                   a.UserId == userId &&
                                   a.QuestionId == gameSession.CurrentQuestionId.Value);

                // Shuffle options consistently (using question id as seed)
                var shuffledOptions = question.Options
                    .OrderBy(o => (o.Id.GetHashCode() ^ gameSession.Id.GetHashCode()))
                    .ToList();

                currentQuestion = new
                {
                    id = question.Id,
                    text = question.Text,
                    imageUrl = question.ImageUrl,
                    points = question.Points,
                    options = shuffledOptions.Select((o, index) => new
                    {
                        id = o.Id,
                        optionKey = ((char)('A' + index)).ToString(),
                        text = o.Text,
                        imageUrl = o.ImageUrl
                    }).ToList()
                };
            }
        }

        // Get all players' current status
        var allPlayers = await _context.GameSessionPlayers
            .Where(p => p.GameSessionId == gameSession.Id)
            .Include(p => p.User)
            .Select(p => new
            {
                userId = p.UserId,
                username = p.User != null ? p.User.Username : "Unknown",
                isEliminated = p.IsEliminated,
                score = p.Score,
                correctAnswers = p.CorrectAnswers,
                wrongAnswers = p.WrongAnswers
            })
            .ToListAsync();

        // Calculate remaining time for current question
        int remainingTime = 60;
        if (gameSession.QuestionStartedAt.HasValue)
        {
            var elapsed = (int)(DateTime.UtcNow - gameSession.QuestionStartedAt.Value).TotalSeconds;
            remainingTime = Math.Max(0, 60 - elapsed);
        }

        // Send rejoin success with full game state
        await Clients.Caller.SendAsync("RejoinSuccess", new
        {
            gameSessionId = gameSession.Id,
            roomId = gameSession.RoomId,
            roomName = gameSession.Room?.Name ?? "Unknown",
            questionIndex = gameSession.CurrentQuestionIndex,
            currentQuestion,
            hasAnsweredCurrentQuestion,
            remainingTime,
            players = allPlayers,
            playerStatus = new
            {
                userId = player.UserId,
                score = player.Score,
                correctAnswers = player.CorrectAnswers,
                wrongAnswers = player.WrongAnswers,
                isEliminated = player.IsEliminated,
                eliminatedAtQuestionIndex = player.EliminatedAtQuestionIndex
            },
            timestamp = DateTime.UtcNow
        });

        // Notify other players that this player reconnected
        await Clients.OthersInGroup(roomId).SendAsync("PlayerReconnected", new
        {
            userId = player.UserId,
            username = player.User?.Username ?? "Unknown"
        });

        _logger.LogInformation("Player {Username} ({UserId}) rejoined game {GameSessionId} in room {RoomId}",
            player.User?.Username ?? "Unknown", userId, gameSession.Id, roomId);
    }

    // ============================================
    // UTILITY METHODS
    // ============================================

    /// <summary>
    /// Get active users in a room
    /// </summary>
    public static int GetRoomPlayerCount(string roomId)
    {
        // Thread-safe read using TryGetValue
        return _roomConnections.TryGetValue(roomId, out var connections) ? connections.Count : 0;
    }

    /// <summary>
    /// Check if user is online
    /// </summary>
    public static bool IsUserOnline(string userId)
    {
        return _connections.ContainsKey(userId);
    }
}
