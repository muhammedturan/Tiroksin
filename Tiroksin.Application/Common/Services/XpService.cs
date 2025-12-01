using Microsoft.EntityFrameworkCore;
using Tiroksin.Domain.Entities;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Application.Common.Services;

public interface IXpService
{
    Task<UserStats> AwardXpAsync(Guid userId, int xp, CancellationToken cancellationToken = default);
    Task UpdateGameStatsAsync(Guid userId, GameSessionPlayer gameResult, CancellationToken cancellationToken = default);
    int CalculateXpForLevel(int level);
}

public class XpService : IXpService
{
    private readonly ApplicationDbContext _context;

    public XpService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserStats> AwardXpAsync(Guid userId, int xp, CancellationToken cancellationToken = default)
    {
        // Get or create user stats
        var stats = await _context.UserStats
            .FirstOrDefaultAsync(s => s.UserId == userId, cancellationToken);

        if (stats == null)
        {
            stats = new UserStats
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Level = 1,
                CurrentXp = 0,
                XpToNextLevel = CalculateXpForLevel(2),
                TotalXp = 0
            };
            _context.UserStats.Add(stats);
        }

        // Add XP
        stats.CurrentXp += xp;
        stats.TotalXp += xp;

        // Check for level up
        while (stats.CurrentXp >= stats.XpToNextLevel)
        {
            stats.CurrentXp -= stats.XpToNextLevel;
            stats.Level++;
            stats.XpToNextLevel = CalculateXpForLevel(stats.Level + 1);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return stats;
    }

    public async Task UpdateGameStatsAsync(
        Guid userId,
        GameSessionPlayer gameResult,
        CancellationToken cancellationToken = default)
    {
        var stats = await _context.UserStats
            .FirstOrDefaultAsync(s => s.UserId == userId, cancellationToken);

        if (stats == null)
        {
            stats = new UserStats
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Level = 1,
                CurrentXp = 0,
                XpToNextLevel = CalculateXpForLevel(2),
                TotalXp = 0
            };
            _context.UserStats.Add(stats);
        }

        // Update game stats
        stats.TotalGamesPlayed++;

        if (gameResult.IsWinner)
        {
            stats.TotalGamesWon++;
            stats.CurrentWinStreak++;

            if (stats.CurrentWinStreak > stats.BestWinStreak)
            {
                stats.BestWinStreak = stats.CurrentWinStreak;
            }
        }
        else
        {
            stats.TotalGamesLost++;
            stats.CurrentWinStreak = 0;
        }

        // Calculate win rate
        stats.WinRate = stats.TotalGamesPlayed > 0
            ? (stats.TotalGamesWon / (double)stats.TotalGamesPlayed) * 100
            : 0;

        // Update question stats (simplified for elimination mode)
        var totalAnswered = gameResult.CorrectAnswers + gameResult.WrongAnswers + gameResult.TimeoutCount;
        stats.TotalQuestionsAnswered += totalAnswered;
        stats.TotalCorrectAnswers += gameResult.CorrectAnswers;
        stats.TotalWrongAnswers += gameResult.WrongAnswers;

        // Calculate accuracy rate
        stats.AccuracyRate = stats.TotalQuestionsAnswered > 0
            ? (stats.TotalCorrectAnswers / (double)stats.TotalQuestionsAnswered) * 100
            : 0;

        // Update records
        if (gameResult.Score > stats.HighestScore)
        {
            stats.HighestScore = gameResult.Score;
        }

        // Note: FastestAnswerTime removed in elimination mode
        // if (gameResult.AverageTimePerQuestion > 0 &&
        //     (stats.FastestAnswerTime == 0 || gameResult.AverageTimePerQuestion < stats.FastestAnswerTime))
        // {
        //     stats.FastestAnswerTime = gameResult.AverageTimePerQuestion;
        // }

        stats.LastPlayedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public int CalculateXpForLevel(int level)
    {
        // XP required increases exponentially
        // Level 2: 100 XP
        // Level 3: 150 XP
        // Level 4: 225 XP
        // Level 5: 337 XP
        // Formula: baseXp * (level - 1) ^ 1.5
        int baseXp = 100;
        return (int)Math.Round(baseXp * Math.Pow(level - 1, 1.5));
    }
}
