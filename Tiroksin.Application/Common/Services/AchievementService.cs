using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Domain.Entities;

namespace Tiroksin.Application.Common.Services;

public interface IAchievementService
{
    Task<List<UnlockedAchievementDto>> CheckAndUnlockAchievementsAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<List<UserAchievementDto>> GetUserAchievementsAsync(Guid userId, CancellationToken cancellationToken = default);
    Task EnsureAchievementsExistAsync(CancellationToken cancellationToken = default);
}

public class AchievementService : IAchievementService
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<AchievementService> _logger;

    // Achievement definitions
    private static readonly List<AchievementDefinition> AchievementDefinitions = new()
    {
        // Victory achievements
        new("FIRST_WIN", "İlk Zafer", "İlk oyununuzu kazandınız!", "🏆", "Victory", 1, 100),
        new("WIN_5", "Seri Kazanan", "5 oyun kazandınız!", "🥇", "Victory", 2, 250),
        new("WIN_10", "Şampiyon", "10 oyun kazandınız!", "👑", "Victory", 3, 500),
        new("WIN_25", "Efsane", "25 oyun kazandınız!", "🌟", "Victory", 4, 1000),

        // Game count achievements
        new("PLAY_1", "Yeni Başlayan", "İlk oyununuzu oynadınız!", "🎮", "Games", 1, 50),
        new("PLAY_10", "Deneyimli", "10 oyun oynadınız!", "🎯", "Games", 2, 150),
        new("PLAY_50", "Kıdemli", "50 oyun oynadınız!", "⭐", "Games", 3, 400),
        new("PLAY_100", "Veteran", "100 oyun oynadınız!", "💎", "Games", 4, 800),

        // Accuracy achievements
        new("ACCURACY_80", "Keskin Nişancı", "Bir oyunda %80+ doğruluk oranı!", "🎯", "Accuracy", 2, 200),
        new("ACCURACY_90", "Mükemmeliyetçi", "Bir oyunda %90+ doğruluk oranı!", "💯", "Accuracy", 3, 350),
        new("PERFECT_GAME", "Kusursuz", "Bir oyunu hiç yanlış yapmadan bitirdiniz!", "✨", "Accuracy", 4, 500),

        // Speed achievements
        new("SPEED_DEMON", "Hız Şeytanı", "Ortalama 5 saniyenin altında cevap verdiniz!", "⚡", "Speed", 3, 300),
        new("LIGHTNING", "Yıldırım", "Bir soruyu 2 saniyenin altında doğru cevaplayın!", "🌩️", "Speed", 2, 150),

        // Score achievements
        new("SCORE_100", "İlk Adım", "Toplam 100 puan kazandınız!", "📈", "Score", 1, 50),
        new("SCORE_1000", "Bin Puan", "Toplam 1000 puan kazandınız!", "📊", "Score", 2, 200),
        new("SCORE_5000", "Puan Canavarı", "Toplam 5000 puan kazandınız!", "🔥", "Score", 3, 500),

        // Streak achievements
        new("STREAK_5", "Başarı Serisi", "5 soruyu üst üste doğru cevaplayın!", "🔗", "Streak", 2, 150),
        new("STREAK_10", "Durdurulamaz", "10 soruyu üst üste doğru cevaplayın!", "💪", "Streak", 3, 300),

        // Special achievements
        new("SURVIVOR", "Hayatta Kalan", "Bir oyunda elenmeden hayatta kaldınız!", "🛡️", "Special", 2, 150),
        new("COMEBACK", "Geri Dönüş", "Son soruda oyunu kazandınız!", "🔄", "Special", 3, 250),
    };

    public AchievementService(IApplicationDbContext context, ILogger<AchievementService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task EnsureAchievementsExistAsync(CancellationToken cancellationToken = default)
    {
        var existingCodes = await _context.Achievements
            .Select(a => a.Code)
            .ToListAsync(cancellationToken);

        var newAchievements = AchievementDefinitions
            .Where(ad => !existingCodes.Contains(ad.Code))
            .Select(ad => new Achievement
            {
                Id = Guid.NewGuid(),
                Code = ad.Code,
                Name = ad.Name,
                Description = ad.Description,
                Icon = ad.Icon,
                Category = ad.Category,
                Difficulty = ad.Difficulty,
                XpReward = ad.XpReward,
                IsActive = true,
                IsHidden = false,
                CreatedAt = DateTime.UtcNow
            })
            .ToList();

        if (newAchievements.Count > 0)
        {
            _context.Achievements.AddRange(newAchievements);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Created {Count} new achievements", newAchievements.Count);
        }
    }

    public async Task<List<UnlockedAchievementDto>> CheckAndUnlockAchievementsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var unlockedAchievements = new List<UnlockedAchievementDto>();

        // Get user stats
        var userStats = await _context.UserStats
            .FirstOrDefaultAsync(us => us.UserId == userId, cancellationToken);

        if (userStats == null) return unlockedAchievements;

        // Get user's existing achievements
        var existingAchievementIds = await _context.UserAchievements
            .Where(ua => ua.UserId == userId && ua.IsCompleted)
            .Select(ua => ua.AchievementId)
            .ToListAsync(cancellationToken);

        // Get all active achievements
        var allAchievements = await _context.Achievements
            .Where(a => a.IsActive)
            .ToListAsync(cancellationToken);

        // Check each achievement
        foreach (var achievement in allAchievements)
        {
            if (existingAchievementIds.Contains(achievement.Id)) continue;

            bool shouldUnlock = CheckAchievementCondition(achievement.Code, userStats);
            if (shouldUnlock)
            {
                // Create or update user achievement
                var userAchievement = await _context.UserAchievements
                    .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AchievementId == achievement.Id, cancellationToken);

                if (userAchievement == null)
                {
                    userAchievement = new UserAchievement
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        AchievementId = achievement.Id,
                        Progress = 100,
                        IsCompleted = true,
                        UnlockedAt = DateTime.UtcNow,
                        CreatedAt = DateTime.UtcNow
                    };
                    _context.UserAchievements.Add(userAchievement);
                }
                else if (!userAchievement.IsCompleted)
                {
                    userAchievement.Progress = 100;
                    userAchievement.IsCompleted = true;
                    userAchievement.UnlockedAt = DateTime.UtcNow;
                    userAchievement.UpdatedAt = DateTime.UtcNow;
                }

                // Add XP reward
                userStats.TotalXp += achievement.XpReward;

                unlockedAchievements.Add(new UnlockedAchievementDto
                {
                    Code = achievement.Code,
                    Name = achievement.Name,
                    Description = achievement.Description,
                    Icon = achievement.Icon,
                    XpReward = achievement.XpReward
                });

                _logger.LogInformation("User {UserId} unlocked achievement: {Code}", userId, achievement.Code);
            }
        }

        if (unlockedAchievements.Count > 0)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        return unlockedAchievements;
    }

    private bool CheckAchievementCondition(string code, UserStats stats)
    {
        return code switch
        {
            // Victory achievements
            "FIRST_WIN" => stats.TotalWins >= 1,
            "WIN_5" => stats.TotalWins >= 5,
            "WIN_10" => stats.TotalWins >= 10,
            "WIN_25" => stats.TotalWins >= 25,

            // Game count achievements
            "PLAY_1" => stats.TotalGamesPlayed >= 1,
            "PLAY_10" => stats.TotalGamesPlayed >= 10,
            "PLAY_50" => stats.TotalGamesPlayed >= 50,
            "PLAY_100" => stats.TotalGamesPlayed >= 100,

            // Score achievements
            "SCORE_100" => stats.TotalScore >= 100,
            "SCORE_1000" => stats.TotalScore >= 1000,
            "SCORE_5000" => stats.TotalScore >= 5000,

            // Accuracy and speed achievements need to be checked at game end
            // These are placeholder checks - actual logic should be in game finish handler
            "ACCURACY_80" => stats.BestAccuracy >= 80,
            "ACCURACY_90" => stats.BestAccuracy >= 90,
            "PERFECT_GAME" => stats.BestAccuracy >= 100,
            "SPEED_DEMON" => stats.FastestAverageTime > 0 && stats.FastestAverageTime <= 5,
            "LIGHTNING" => stats.FastestAnswerTime > 0 && stats.FastestAnswerTime <= 2,

            // Streak achievements
            "STREAK_5" => stats.BestStreak >= 5,
            "STREAK_10" => stats.BestStreak >= 10,

            // Special achievements - these need specific game conditions
            "SURVIVOR" => stats.TotalWins >= 1, // Simplified - winner is survivor
            "COMEBACK" => false, // This needs game-specific logic

            _ => false
        };
    }

    public async Task<List<UserAchievementDto>> GetUserAchievementsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var userAchievements = await _context.UserAchievements
            .Where(ua => ua.UserId == userId)
            .Include(ua => ua.Achievement)
            .Select(ua => new UserAchievementDto
            {
                Code = ua.Achievement.Code,
                Name = ua.Achievement.Name,
                Description = ua.Achievement.Description,
                Icon = ua.Achievement.Icon,
                Category = ua.Achievement.Category,
                Difficulty = ua.Achievement.Difficulty,
                XpReward = ua.Achievement.XpReward,
                Progress = ua.Progress,
                IsCompleted = ua.IsCompleted,
                UnlockedAt = ua.UnlockedAt
            })
            .OrderByDescending(ua => ua.UnlockedAt)
            .ToListAsync(cancellationToken);

        return userAchievements;
    }

    private record AchievementDefinition(string Code, string Name, string Description, string Icon, string Category, int Difficulty, int XpReward);
}

public record UnlockedAchievementDto
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Icon { get; init; } = string.Empty;
    public int XpReward { get; init; }
}

public record UserAchievementDto
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Icon { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public int Difficulty { get; init; }
    public int XpReward { get; init; }
    public int Progress { get; init; }
    public bool IsCompleted { get; init; }
    public DateTime? UnlockedAt { get; init; }
}
