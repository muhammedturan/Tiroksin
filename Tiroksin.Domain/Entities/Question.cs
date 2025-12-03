using Tiroksin.Core.BaseClasses;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Domain.Entities;

public class Question : AuditEntity
{
    // Soru Bilgileri
    public string Text { get; set; } = string.Empty; // Soru metni
    public string? ImageUrl { get; set; } // Opsiyonel görsel
    public OptionsLayout OptionsLayout { get; set; } = OptionsLayout.Vertical; // Şıkların düzeni

    // Kategorizasyon
    public ExamType ExamType { get; set; } // Sınav tipi (YKS-TYT, LGS, vb.)

    // Parameters - stores references to ParameterDefinition values
    public string? Category { get; set; } // Kategori (Matematik, Fizik, vb.)
    public string? Subject { get; set; } // Konu (Türev, Integral, vb.)
    public string? Topic { get; set; } // Alt konu

    // Durum
    public QuestionStatus Status { get; set; } = QuestionStatus.Pending; // Onay durumu
    public bool IsPublic { get; set; } = true; // Herkese açık mı?

    // İstatistikler
    public int ViewCount { get; set; } = 0; // Görüntülenme sayısı
    public int AttemptCount { get; set; } = 0; // Çözülme sayısı
    public int CorrectCount { get; set; } = 0; // Doğru çözülme sayısı

    // Puanlama (dinamik hesaplanacak)
    public int Points { get; set; } = 0; // Algoritma ile hesaplanacak

    // Navigation Properties
    public virtual User Creator { get; set; } = null!;
    public virtual ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();
    // NOTE: Subject, Topic, Category now stored via ParameterValue system
    // NOTE: ExamQuestion and UserAnswer removed - Elimination mode only uses GameAnswer
}
