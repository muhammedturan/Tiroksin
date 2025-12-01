using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Domain.Entities;
using Tiroksin.Domain.Enums;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Application.Rooms.Commands.StartGame;

public class StartGameCommandHandler : IRequestHandler<StartGameCommand, StartGameResponse>
{
    private readonly ApplicationDbContext _context;

    public StartGameCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StartGameResponse> Handle(StartGameCommand request, CancellationToken cancellationToken)
    {
        // Get room with players
        var room = await _context.Rooms
            .Include(r => r.Players)
            .FirstOrDefaultAsync(r => r.Id == request.RoomId, cancellationToken);

        if (room == null)
        {
            return new StartGameResponse { Success = false, Message = "Oda bulunamadı!" };
        }

        // Check if user is host
        if (room.HostUserId != request.UserId)
        {
            return new StartGameResponse { Success = false, Message = "Sadece oda sahibi oyunu başlatabilir!" };
        }

        // Check minimum players
        var activePlayers = room.Players.Where(p => p.LeftAt == null).ToList();
        if (activePlayers.Count < room.MinPlayers)
        {
            return new StartGameResponse { Success = false, Message = $"En az {room.MinPlayers} oyuncu gerekli!" };
        }

        // Select first random question
        var firstQuestion = await SelectRandomQuestionAsync(new List<Guid>(), cancellationToken);
        if (firstQuestion == null)
        {
            return new StartGameResponse { Success = false, Message = "Soru bulunamadı!" };
        }

        // Create game session
        var gameSession = new GameSession
        {
            Id = Guid.NewGuid(),
            RoomId = room.Id,
            Status = RoomStatus.InProgress,
            CurrentQuestionIndex = 0,
            CurrentQuestionId = firstQuestion.Id,
            StartedAt = DateTime.UtcNow,
            QuestionStartedAt = DateTime.UtcNow
        };
        _context.GameSessions.Add(gameSession);

        // Create game session players
        foreach (var player in activePlayers)
        {
            _context.GameSessionPlayers.Add(new GameSessionPlayer
            {
                Id = Guid.NewGuid(),
                GameSessionId = gameSession.Id,
                UserId = player.UserId,
                Score = 0,
                CorrectAnswers = 0,
                WrongAnswers = 0,
                TimeoutCount = 0,
                Rank = 0,
                IsEliminated = false,
                IsWinner = false
            });
            player.Status = PlayerStatus.Playing;
        }

        // Update room status
        room.Status = RoomStatus.InProgress;
        room.StartedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        // Prepare first question DTO
        var questionDto = new GameQuestionDto
        {
            Id = firstQuestion.Id,
            Text = firstQuestion.Text,
            ImageUrl = firstQuestion.ImageUrl,
            Points = firstQuestion.Points,
            Options = firstQuestion.Options
                .OrderBy(o => Guid.NewGuid()) // Shuffle options
                .Select((o, index) => new GameOptionDto
                {
                    Id = o.Id,
                    OptionKey = ((char)('A' + index)).ToString(),
                    Text = o.Text,
                    ImageUrl = o.ImageUrl
                }).ToList()
        };

        return new StartGameResponse
        {
            GameSessionId = gameSession.Id,
            Questions = new List<GameQuestionDto> { questionDto },
            Success = true,
            Message = "Oyun başlıyor!"
        };
    }

    private async Task<Question?> SelectRandomQuestionAsync(List<Guid> excludeIds, CancellationToken cancellationToken)
    {
        var query = _context.Questions
            .Include(q => q.Options)
            .Where(q => q.Status == QuestionStatus.Approved);

        if (excludeIds.Any())
        {
            query = query.Where(q => !excludeIds.Contains(q.Id));
        }

        return await query
            .OrderBy(q => Guid.NewGuid())
            .FirstOrDefaultAsync(cancellationToken);
    }
}
