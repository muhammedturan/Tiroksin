using Tiroksin.Core.BaseClasses;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Odadaki oyuncular - Kim hangi odada, hazır mı değil mi?
/// </summary>
public class RoomPlayer : AuditEntity
{
    public Guid RoomId { get; set; }
    public Guid UserId { get; set; }

    public PlayerStatus Status { get; set; } = PlayerStatus.Waiting;
    public bool IsReady { get; set; } = false; // Oyuncu hazır mı?
    public int? Team { get; set; } // Takım numarası (takım oyunları için)
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LeftAt { get; set; }

    // Navigation Properties
    public virtual Room Room { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
