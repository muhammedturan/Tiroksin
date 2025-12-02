using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Domain.Entities;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Application.GameSessions.Commands.MarkPlayerFinished;

public class MarkPlayerFinishedCommandHandler : IRequestHandler<MarkPlayerFinishedCommand, MarkPlayerFinishedResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<MarkPlayerFinishedCommandHandler> _logger;

    public MarkPlayerFinishedCommandHandler(IApplicationDbContext context, ILogger<MarkPlayerFinishedCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<MarkPlayerFinishedResponse> Handle(MarkPlayerFinishedCommand request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("MarkPlayerFinished received for GameSession: {GameSessionId}, User: {UserId}", request.GameSessionId, request.UserId);

        // Get game session
        var gameSession = await _context.GameSessions
            .Include(gs => gs.Room)
            .FirstOrDefaultAsync(gs => gs.Id == request.GameSessionId, cancellationToken);

        if (gameSession == null)
        {
            return new MarkPlayerFinishedResponse
            {
                Success = false,
                Message = "Oyun oturumu bulunamadı! 🔍"
            };
        }

        // Check if game is still in progress
        if (gameSession.Status != RoomStatus.InProgress)
        {
            return new MarkPlayerFinishedResponse
            {
                Success = false,
                Message = "Oyun bitti veya henüz başlamadı! ⏸️"
            };
        }

        // Get game session player
        var gameSessionPlayer = await _context.GameSessionPlayers
            .FirstOrDefaultAsync(gsp =>
                gsp.GameSessionId == request.GameSessionId &&
                gsp.UserId == request.UserId,
                cancellationToken);

        if (gameSessionPlayer == null)
        {
            return new MarkPlayerFinishedResponse
            {
                Success = false,
                Message = "Oyuncu bulunamadı! 🔍"
            };
        }

        // NOTE: This handler is for Classic mode where players finish at different times.
        // In Elimination mode, this is not used - players are eliminated immediately on wrong answer
        // and the game progresses together for all remaining players.
        // Keeping this handler for potential future use or migration.

        _logger.LogDebug("MarkPlayerFinished called but not applicable in Elimination mode");

        // Get player stats from existing answers
        var playerAnswers = await _context.GameAnswers
            .Where(ga => ga.GameSessionId == request.GameSessionId && ga.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        int correctAnswers = playerAnswers.Count(a => a.IsCorrect);
        int wrongAnswers = playerAnswers.Count(a => !a.IsCorrect && a.SelectedOptionId.HasValue);
        int timeoutCount = playerAnswers.Count(a => a.IsTimeout);

        // Update player stats (basic stats only - scores calculated in SubmitAnswerCommandHandler)
        gameSessionPlayer.CorrectAnswers = correctAnswers;
        gameSessionPlayer.WrongAnswers = wrongAnswers;
        gameSessionPlayer.TimeoutCount = timeoutCount;

        await _context.SaveChangesAsync(cancellationToken);

        // In elimination mode, all non-eliminated players are always in sync
        var allPlayers = await _context.GameSessionPlayers
            .Where(gsp => gsp.GameSessionId == request.GameSessionId && !gsp.IsEliminated)
            .CountAsync(cancellationToken);

        bool allPlayersFinished = allPlayers <= 1; // Game ends when 1 or 0 players remain

        _logger.LogDebug("Active (non-eliminated) players: {ActivePlayers}, Game finished: {AllFinished}", allPlayers, allPlayersFinished);
        _logger.LogDebug("Player stats - Correct: {Correct}, Wrong: {Wrong}, Timeouts: {Timeouts}", correctAnswers, wrongAnswers, timeoutCount);

        return new MarkPlayerFinishedResponse
        {
            Success = true,
            Message = allPlayersFinished
                ? "✅ Oyun bitti! Sonuçlar hesaplanıyor..."
                : $"✅ Cevabın kaydedildi!",
            AllPlayersFinished = allPlayersFinished,
            TotalPlayers = allPlayers,
            FinishedPlayers = allPlayers // In elimination mode, all active players are always "finished" with current question
        };
    }
}
