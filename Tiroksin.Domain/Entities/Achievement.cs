using Tiroksin.Core.BaseClasses;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Başarı rozetleri - Oyuncuların kazandığı ödüller
/// </summary>
public class Achievement : AuditEntity
{
    // Başarı Bilgileri
    public string Code { get; set; } = string.Empty; // Benzersiz kod (örn: "FIRST_WIN")
    public string Name { get; set; } = string.Empty; // Başarı adı
    public string Description { get; set; } = string.Empty; // Açıklama
    public string Icon { get; set; } = "🏆"; // Emoji veya ikon URL

    // Kategori ve Zorluk
    public string Category { get; set; } = string.Empty; // Kategori (örn: "Victory", "Speed", "Accuracy")
    public int Difficulty { get; set; } = 1; // Zorluk (1-5)
    public int XpReward { get; set; } = 0; // XP ödülü

    // Koşullar (JSON olarak saklanabilir)
    public string? Requirements { get; set; } // JSON: {"wins": 10, "accuracy": 90}

    public bool IsHidden { get; set; } = false; // Gizli başarı mı?
    public bool IsActive { get; set; } = true; // Aktif mi?

    // Navigation Properties
    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
