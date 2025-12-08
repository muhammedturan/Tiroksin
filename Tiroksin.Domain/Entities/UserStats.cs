using Tiroksin.Core.BaseClasses;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Kullanıcı istatistikleri ve gamification verileri
/// </summary>
public class UserStats : AuditEntity
{
    public Guid UserId { get; set; }

    // Level ve XP Sistemi
    public int Level { get; set; } = 1; // Oyuncu seviyesi
    public int CurrentXp { get; set; } = 0; // Şu anki XP
    public int XpToNextLevel { get; set; } = 100; // Sonraki level için gereken XP
    public int TotalXp { get; set; } = 0; // Toplam kazanılan XP

    // Oyun İstatistikleri
    public int TotalGamesPlayed { get; set; } = 0; // Toplam oyun sayısı
    public int TotalGamesWon { get; set; } = 0; // Kazanılan oyun sayısı
    public int TotalGamesLost { get; set; } = 0; // Kaybedilen oyun sayısı
    public double WinRate { get; set; } = 0.0; // Kazanma oranı (%)

    // Soru İstatistikleri
    public int TotalQuestionsAnswered { get; set; } = 0; // Toplam cevaplanan soru
    public int TotalCorrectAnswers { get; set; } = 0; // Toplam doğru cevap
    public int TotalWrongAnswers { get; set; } = 0; // Toplam yanlış cevap
    public double AccuracyRate { get; set; } = 0.0; // Doğruluk oranı (%)

    // Streak ve Rekor
    public int CurrentWinStreak { get; set; } = 0; // Mevcut kazanma serisi
    public int BestWinStreak { get; set; } = 0; // En iyi kazanma serisi
    public int HighestScore { get; set; } = 0; // En yüksek skor
    public int FastestAnswerTime { get; set; } = 0; // En hızlı cevap (saniye)

    // Achievement-specific stats
    public int TotalWins { get; set; } = 0; // Total wins (same as TotalGamesWon, kept for clarity)
    public int TotalScore { get; set; } = 0; // Total cumulative score
    public int BestAccuracy { get; set; } = 0; // Best accuracy in a single game (0-100)
    public int FastestAverageTime { get; set; } = 0; // Fastest average answer time in a game (seconds)
    public int BestStreak { get; set; } = 0; // Best correct answer streak in a single game

    // Sıralama
    public int GlobalRank { get; set; } = 0; // Genel sıralama
    public int WeeklyRank { get; set; } = 0; // Haftalık sıralama
    public int MonthlyRank { get; set; } = 0; // Aylık sıralama

    // Son Aktivite
    public DateTime? LastPlayedAt { get; set; } // Son oyun tarihi

    // Navigation Properties
    public virtual User User { get; set; } = null!;
}
