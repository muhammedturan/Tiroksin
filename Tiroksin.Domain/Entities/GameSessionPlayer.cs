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
    public int Score { get; set; } = 0;
    public int CorrectAnswers { get; set; } = 0;
    public int WrongAnswers { get; set; } = 0;
    public int TimeoutCount { get; set; } = 0;
    public int Rank { get; set; } = 0;

    // Elimination mode specific
    public bool IsEliminated { get; set; } = false;
    public int? EliminatedAtQuestionIndex { get; set; }
    public bool IsWinner { get; set; } = false;

    // Navigation Properties
    public virtual GameSession GameSession { get; set; } = null!;
    public virtual User User { get; set; } = null!;

    // ============================================
    // DOMAIN METHODS
    // ============================================

    /// <summary>
    /// Yeni oyuncu oluştur
    /// </summary>
    public static GameSessionPlayer Create(Guid gameSessionId, Guid userId)
    {
        return new GameSessionPlayer
        {
            Id = Guid.NewGuid(),
            GameSessionId = gameSessionId,
            UserId = userId
        };
    }

    /// <summary>
    /// Cevabı kaydet ve skor hesapla
    /// </summary>
    public void RecordAnswer(bool isCorrect, bool isTimeout, int points, int currentQuestionIndex)
    {
        if (IsEliminated)
            throw new InvalidOperationException("Elenmiş oyuncu cevap veremez");

        if (isCorrect)
        {
            CorrectAnswers++;
            Score += points;
        }
        else
        {
            WrongAnswers++;
            // Survival modunda yanlış cevap = eleme
            Eliminate(currentQuestionIndex);
        }

        if (isTimeout)
            TimeoutCount++;
    }

    /// <summary>
    /// Oyuncuyu ele
    /// </summary>
    public void Eliminate(int questionIndex)
    {
        if (IsEliminated) return;

        IsEliminated = true;
        EliminatedAtQuestionIndex = questionIndex;
    }

    /// <summary>
    /// Kazanan olarak işaretle
    /// </summary>
    public void MarkAsWinner()
    {
        if (IsEliminated)
            throw new InvalidOperationException("Elenmiş oyuncu kazanamaz");

        IsWinner = true;
        Rank = 1;
    }

    /// <summary>
    /// Sıralama ata
    /// </summary>
    public void SetRank(int rank)
    {
        if (rank < 1)
            throw new ArgumentException("Sıralama 1'den küçük olamaz");
        Rank = rank;
    }
}
