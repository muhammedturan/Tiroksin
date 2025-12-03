using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Application.Rooms.Queries.GetRooms;

public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, List<RoomDto>>
{
    private readonly IApplicationDbContext _context;

    public GetRoomsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<RoomDto>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Rooms
            .Include(r => r.Host)
            .Include(r => r.Players)
            .AsQueryable();

        // Apply filters
        if (request.IsPublic.HasValue)
        {
            query = query.Where(r => r.IsPublic == request.IsPublic.Value);
        }

        if (request.Status.HasValue)
        {
            query = query.Where(r => r.Status == request.Status.Value);
        }

        // GameMode filter removed - always elimination mode

        // Get active rooms (only Waiting - not InProgress, Finished, or Cancelled)
        // Players can only join rooms that haven't started yet
        query = query.Where(r => r.Status == RoomStatus.Waiting);

        var rooms = await query
            .OrderByDescending(r => r.CreatedAt)
            .Select(r => new RoomDto
            {
                Id = r.Id,
                RoomCode = r.RoomCode,
                Name = r.Name,
                Description = r.Description,
                GameMode = GameMode.Survival, // Always elimination
                Status = r.Status,
                CurrentPlayers = r.Players.Count(p => p.LeftAt == null),
                MaxPlayers = r.MaxPlayers,
                MinPlayers = r.MinPlayers,
                IsPublic = r.IsPublic,
                IsPasswordProtected = r.IsPasswordProtected,
                QuestionCount = r.QuestionCount,
                TimePerQuestion = 60, // Always 60 seconds
                CategoryName = null, // No categories in elimination mode
                SubjectName = null, // No subjects in elimination mode
                HostUsername = r.Host.Username,
                HostAvatar = r.Host.Avatar,
                CreatedAt = r.CreatedAt
            })
            .ToListAsync(cancellationToken);

        return rooms;
    }
}
