using Tiroksin.Core.BaseClasses;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Oyundaki oyuncu skorları ve istatistikleri
/// </summary>
public class GameSessionPlayer : AuditEntity
{
    public Guid GameSessionId { get; set; }
    public Guid UserId { get; set; }

    // Skor ve İstatistikler
    public int Score { get; set; } = 0; // Toplam puan
    public int CorrectAnswers { get; set; } = 0; // Doğru sayısı
    public int WrongAnswers { get; set; } = 0; // Yanlış sayısı
    public int TimeoutCount { get; set; } = 0; // Timeout sayısı
    public int Rank { get; set; } = 0; // Final sıralama (1, 2, 3...)

    // Elimination mode specific
    public bool IsEliminated { get; set; } = false; // Elendi mi?
    public int? EliminatedAtQuestionIndex { get; set; } // Hangi soruda elendi?
    public bool IsWinner { get; set; } = false; // Kazandı mı?

    // Navigation Properties
    public virtual GameSession GameSession { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
