using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tiroksin.Application.Common.DTOs;
using Tiroksin.Application.Common.Services;
using Tiroksin.Domain.Enums;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Application.GameSessions.Commands.FinishGame;

public class FinishGameCommandHandler : IRequestHandler<FinishGameCommand, FinishGameResponse>
{
    private readonly ApplicationDbContext _context;
    private readonly IXpService _xpService;
    private readonly ILogger<FinishGameCommandHandler> _logger;

    public FinishGameCommandHandler(ApplicationDbContext context, IXpService xpService, ILogger<FinishGameCommandHandler> logger)
    {
        _context = context;
        _xpService = xpService;
        _logger = logger;
    }

    public async Task<FinishGameResponse> Handle(FinishGameCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("FinishGameCommand received for GameSession: {GameSessionId}", request.GameSessionId);

        var gameSession = await _context.GameSessions
            .Include(gs => gs.Room)
            .Include(gs => gs.Players)
                .ThenInclude(p => p.User)
            .FirstOrDefaultAsync(gs => gs.Id == request.GameSessionId, cancellationToken);

        if (gameSession == null)
        {
            _logger.LogWarning("Game session not found: {GameSessionId}", request.GameSessionId);
            return new FinishGameResponse
            {
                Success = false,
                Message = "Oyun oturumu bulunamadı! 🔍"
            };
        }

        _logger.LogDebug("Game session found. Status: {Status}, Players count: {PlayerCount}", gameSession.Status, gameSession.Players?.Count ?? 0);

        if (gameSession.Status == RoomStatus.Finished)
        {
            _logger.LogWarning("Game already finished: {GameSessionId}", request.GameSessionId);
            return new FinishGameResponse
            {
                Success = false,
                Message = "Oyun zaten bitti! 🏁"
            };
        }

        // Calculate rankings (Elimination mode - by score only)
        var rankedPlayers = gameSession.Players
            .OrderByDescending(p => p.Score)
            .ThenBy(p => p.IsEliminated) // Non-eliminated players ranked higher
            .ThenBy(p => p.EliminatedAtQuestionIndex ?? int.MaxValue) // Eliminated later = higher rank
            .ToList();

        _logger.LogDebug("Ranked {PlayerCount} players for GameSession: {GameSessionId}", rankedPlayers.Count, request.GameSessionId);

        var results = new List<PlayerResultDto>();

        // Get total questions count from distinct questions answered in this session
        var totalQuestionsInGame = await _context.GameAnswers
            .Where(a => a.GameSessionId == request.GameSessionId)
            .Select(a => a.QuestionId)
            .Distinct()
            .CountAsync(cancellationToken);

        for (int i = 0; i < rankedPlayers.Count; i++)
        {
            var player = rankedPlayers[i];
            player.Rank = i + 1;
            player.IsWinner = i == 0; // First place wins

            int xpEarned = CalculateXp(
                rank: player.Rank,
                totalPlayers: rankedPlayers.Count,
                correctAnswers: player.CorrectAnswers,
                totalQuestions: totalQuestionsInGame,
                isWinner: player.IsWinner);

            // Award XP and level up
            var updatedStats = await _xpService.AwardXpAsync(player.UserId, xpEarned, cancellationToken);

            // Update game stats
            await _xpService.UpdateGameStatsAsync(player.UserId, player, cancellationToken);

            results.Add(new PlayerResultDto
            {
                UserId = player.UserId,
                Username = player.User.Username,
                Avatar = player.User.Avatar,
                Rank = player.Rank,
                Score = player.Score,
                CorrectAnswers = player.CorrectAnswers,
                WrongAnswers = player.WrongAnswers,
                UnansweredCount = player.TimeoutCount, // Timeouts in elimination mode
                TotalTimeSpent = 0, // Not tracked in elimination mode
                AverageTimePerQuestion = 0, // Not tracked in elimination mode
                XpEarned = xpEarned,
                NewLevel = updatedStats.Level,
                NewXp = updatedStats.CurrentXp,
                IsWinner = player.IsWinner,
                AchievementsUnlocked = new List<string>() // TODO: Check achievements
            });
        }

        // Fetch all players' answers for review
        var allAnswers = await _context.GameAnswers
            .Include(ga => ga.User)
            .Where(ga => ga.GameSessionId == request.GameSessionId)
            .ToListAsync(cancellationToken);

        _logger.LogDebug("Fetched {AnswerCount} player answers for review", allAnswers.Count);

        // Group answers by question ID
        var allPlayersAnswers = allAnswers
            .GroupBy(ga => ga.QuestionId)
            .ToDictionary(
                g => g.Key,
                g => g.Select(ga => new PlayerAnswerDto
                {
                    UserId = ga.UserId,
                    Username = ga.User.Username,
                    Avatar = ga.User.Avatar ?? "👤",
                    SelectedOptionId = ga.SelectedOptionId,
                    IsCorrect = ga.IsCorrect,
                    TimeSpent = ga.TimeSpent
                }).ToList()
            );

        _logger.LogDebug("Grouped answers by {QuestionCount} questions", allPlayersAnswers.Count);

        // Update game session status
        gameSession.Status = RoomStatus.Finished;
        gameSession.FinishedAt = DateTime.UtcNow;

        // Update room status
        if (gameSession.Room != null)
        {
            gameSession.Room.Status = RoomStatus.Finished;
            gameSession.Room.FinishedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return new FinishGameResponse
        {
            Results = results,
            AllPlayersAnswers = allPlayersAnswers,
            Success = true,
            Message = "Oyun bitti! 🏁"
        };
    }

    private int CalculateXp(int rank, int totalPlayers, int correctAnswers, int totalQuestions, bool isWinner)
    {
        // Base XP per correct answer
        int baseXp = correctAnswers * 10;

        // Rank bonus (winner gets most bonus)
        double rankMultiplier = rank switch
        {
            1 => 2.0,  // Winner: 100% bonus
            2 => 1.5,  // 2nd: 50% bonus
            3 => 1.25, // 3rd: 25% bonus
            _ => 1.0   // Others: no bonus
        };

        // Accuracy bonus
        double accuracy = totalQuestions > 0 ? correctAnswers / (double)totalQuestions : 0;
        double accuracyBonus = accuracy * 50; // Max 50 XP bonus for 100% accuracy

        // Participation XP (everyone gets this)
        int participationXp = 25;

        int totalXp = (int)Math.Round((baseXp * rankMultiplier) + accuracyBonus + participationXp);

        return Math.Max(totalXp, 25); // Minimum 25 XP
    }
}
