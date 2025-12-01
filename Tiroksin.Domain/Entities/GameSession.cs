using Tiroksin.Core.BaseClasses;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Başlatılmış oyun oturumu - Gerçek oyun burada oynanır
/// </summary>
public class GameSession : AuditEntity
{
    public Guid RoomId { get; set; }

    // Oyun Durumu
    public RoomStatus Status { get; set; } = RoomStatus.InProgress;
    public int CurrentQuestionIndex { get; set; } = 0; // Kaçıncı soru (0-indexed)
    public Guid? CurrentQuestionId { get; set; } // Şu an sorulan sorunun ID'si
    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    public DateTime? QuestionStartedAt { get; set; } // Mevcut sorunun başladığı zaman (timer için)
    public DateTime? FinishedAt { get; set; }

    // Navigation Properties
    public virtual Room Room { get; set; } = null!;
    public virtual Question? CurrentQuestion { get; set; }
    public virtual ICollection<GameSessionPlayer> Players { get; set; } = new List<GameSessionPlayer>();
    public virtual ICollection<GameAnswer> Answers { get; set; } = new List<GameAnswer>();
}
