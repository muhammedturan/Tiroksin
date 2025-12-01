using Tiroksin.Core.BaseClasses;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Oyun odası - Batak/Okey benzeri multiplayer odalar
/// </summary>
public class Room : AuditEntity
{
    // Oda Bilgileri
    public string RoomCode { get; set; } = string.Empty; // Davet kodu (örn: "ABC123")
    public string Name { get; set; } = string.Empty; // Oda adı
    public string? Description { get; set; } // Oda açıklaması

    // Oda Ayarları
    public RoomStatus Status { get; set; } = RoomStatus.Waiting;
    public int MaxPlayers { get; set; } = 10; // Maksimum oyuncu sayısı (2-10)
    public int MinPlayers { get; set; } = 2; // Minimum oyuncu sayısı
    public bool IsPublic { get; set; } = true; // Herkese açık mı?
    public bool IsPasswordProtected { get; set; } = false;
    public string? PasswordHash { get; set; } // Şifreli odalar için

    // Oyun Ayarları (Elimination mode only - 60 seconds per question is hardcoded)
    public int QuestionCount { get; set; } = 20; // Soru sayısı (5-50)

    // Oda Lideri
    public Guid HostUserId { get; set; } // Oda sahibi

    // Oyun Zamanlaması
    public DateTime? StartedAt { get; set; } // Oyun başlama zamanı
    public DateTime? FinishedAt { get; set; } // Oyun bitiş zamanı

    // Navigation Properties
    public virtual User Host { get; set; } = null!;
    public virtual ICollection<RoomPlayer> Players { get; set; } = new List<RoomPlayer>();
    public virtual ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();
}
