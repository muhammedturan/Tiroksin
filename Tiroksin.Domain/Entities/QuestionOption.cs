using Tiroksin.Core.BaseClasses;

namespace Tiroksin.Domain.Entities;

public class QuestionOption : BaseEntity
{
    public Guid QuestionId { get; set; }
    public string OptionKey { get; set; } = string.Empty; // A, B, C, D, E
    public string Text { get; set; } = string.Empty; // Şık metni
    public string? ImageUrl { get; set; } // Şık görseli (opsiyonel)
    public bool IsCorrect { get; set; } = false; // Doğru cevap mı?

    // Navigation Properties
    public virtual Question Question { get; set; } = null!;
}
