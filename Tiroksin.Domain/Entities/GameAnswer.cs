using Tiroksin.Core.BaseClasses;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Oyun sırasında verilen cevaplar - Realtime tracking
/// </summary>
public class GameAnswer : AuditEntity
{
    public Guid GameSessionId { get; set; }
    public Guid UserId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid? SelectedOptionId { get; set; } // Null ise boş

    public bool IsCorrect { get; set; } = false;
    public int TimeSpent { get; set; } = 0; // Saniye cinsinden
    public bool IsTimeout { get; set; } = false; // 60 saniye doldu mu?

    public DateTime AnsweredAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public virtual GameSession GameSession { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public virtual Question Question { get; set; } = null!;
    public virtual QuestionOption? SelectedOption { get; set; }
}
