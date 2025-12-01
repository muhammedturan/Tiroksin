using Tiroksin.Core.BaseClasses;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Kullanıcının kazandığı başarılar
/// </summary>
public class UserAchievement : AuditEntity
{
    public Guid UserId { get; set; }
    public Guid AchievementId { get; set; }

    public DateTime UnlockedAt { get; set; } = DateTime.UtcNow; // Kazanma tarihi
    public int Progress { get; set; } = 0; // İlerleme (0-100)
    public bool IsCompleted { get; set; } = false; // Tamamlandı mı?

    // Navigation Properties
    public virtual User User { get; set; } = null!;
    public virtual Achievement Achievement { get; set; } = null!;
}
