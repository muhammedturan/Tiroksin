using Tiroksin.Core.BaseClasses;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Oyun odası - Batak/Okey benzeri multiplayer odalar
/// </summary>
public class Room : AuditEntity
{
    // Oda Bilgileri
    public string RoomCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    // Oda Ayarları
    public RoomStatus Status { get; set; } = RoomStatus.Waiting;
    public int MaxPlayers { get; set; } = 10;
    public int MinPlayers { get; set; } = 2;
    public bool IsPublic { get; set; } = true;
    public bool IsPasswordProtected { get; set; } = false;
    public string? PasswordHash { get; set; }

    // Oyun Ayarları
    public int QuestionCount { get; set; } = 20;

    // Oda Lideri
    public Guid HostUserId { get; set; }

    // Oyun Zamanlaması
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public DateTime ExpiresAt { get; set; } // Oda geçerlilik süresi (default: 2 saat)

    // Navigation Properties
    public virtual User Host { get; set; } = null!;
    public virtual ICollection<RoomPlayer> Players { get; set; } = new List<RoomPlayer>();
    public virtual ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();

    // ============================================
    // DOMAIN METHODS
    // ============================================

    /// <summary>
    /// Oda oluşturma için factory method
    /// </summary>
    public static Room Create(
        string name,
        Guid hostUserId,
        string roomCode,
        int maxPlayers = 10,
        int minPlayers = 2,
        int questionCount = 20,
        bool isPublic = true,
        string? password = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Oda adı boş olamaz", nameof(name));
        if (maxPlayers < minPlayers)
            throw new ArgumentException("Maksimum oyuncu sayısı minimum oyuncu sayısından az olamaz");
        if (minPlayers < 2)
            throw new ArgumentException("Minimum 2 oyuncu gereklidir");
        if (questionCount < 5 || questionCount > 50)
            throw new ArgumentException("Soru sayısı 5-50 arasında olmalıdır");

        var room = new Room
        {
            Id = Guid.NewGuid(),
            Name = name,
            RoomCode = roomCode.ToUpperInvariant(),
            HostUserId = hostUserId,
            MaxPlayers = maxPlayers,
            MinPlayers = minPlayers,
            QuestionCount = questionCount,
            IsPublic = isPublic,
            Status = RoomStatus.Waiting,
            ExpiresAt = DateTime.UtcNow.AddHours(2) // 2 saat sonra expire
        };

        if (!string.IsNullOrWhiteSpace(password))
        {
            room.IsPasswordProtected = true;
            room.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        return room;
    }

    /// <summary>
    /// Oda süresi dolmuş mu kontrol et
    /// </summary>
    public bool IsExpired() => DateTime.UtcNow >= ExpiresAt;

    /// <summary>
    /// Odaya oyuncu eklenebilir mi kontrol et
    /// </summary>
    public bool CanJoin() => Status == RoomStatus.Waiting && !IsExpired() && GetActivePlayerCount() < MaxPlayers;

    /// <summary>
    /// Oyun başlatılabilir mi kontrol et
    /// </summary>
    public bool CanStart() => Status == RoomStatus.Waiting && GetActivePlayerCount() >= MinPlayers;

    /// <summary>
    /// Aktif oyuncu sayısını al
    /// </summary>
    public int GetActivePlayerCount() => Players.Count(p => p.LeftAt == null);

    /// <summary>
    /// Şifre doğrulaması
    /// </summary>
    public bool VerifyPassword(string? password)
    {
        if (!IsPasswordProtected) return true;
        if (string.IsNullOrWhiteSpace(password)) return false;
        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }

    /// <summary>
    /// Oyunu başlat
    /// </summary>
    public void StartGame()
    {
        if (Status != RoomStatus.Waiting)
            throw new InvalidOperationException($"Oyun şu anda {Status} durumunda, başlatılamaz");

        var activePlayerCount = GetActivePlayerCount();
        if (activePlayerCount < MinPlayers)
            throw new InvalidOperationException($"En az {MinPlayers} oyuncu gerekli. Şu an: {activePlayerCount}");

        Status = RoomStatus.InProgress;
        StartedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Oyunu bitir
    /// </summary>
    public void FinishGame()
    {
        if (Status == RoomStatus.Finished) return;

        Status = RoomStatus.Finished;
        FinishedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Oda bilgilerini güncelle (sadece host yapabilir)
    /// </summary>
    public void UpdateSettings(Guid userId, string? name = null, string? description = null)
    {
        if (userId != HostUserId)
            throw new UnauthorizedAccessException("Sadece oda sahibi ayarları değiştirebilir");
        if (Status != RoomStatus.Waiting)
            throw new InvalidOperationException("Oyun başladıktan sonra ayarlar değiştirilemez");

        if (!string.IsNullOrWhiteSpace(name))
            Name = name;
        if (description != null)
            Description = description;
    }
}
