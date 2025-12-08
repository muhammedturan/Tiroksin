using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Application.GameSessions.Queries.GetActiveGameSession;

public class GetActiveGameSessionQueryHandler : IRequestHandler<GetActiveGameSessionQuery, GetActiveGameSessionResponse?>
{
    private readonly IApplicationDbContext _context;

    public GetActiveGameSessionQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetActiveGameSessionResponse?> Handle(GetActiveGameSessionQuery request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;

        // Find active game session where user is a player
        // Only return if: status is InProgress AND room hasn't expired
        var activeSession = await _context.GameSessionPlayers
            .Where(gsp => gsp.UserId == request.UserId)
            .Include(gsp => gsp.GameSession)
                .ThenInclude(gs => gs.Room)
            .Where(gsp => gsp.GameSession.Status == RoomStatus.InProgress)
            .Where(gsp => gsp.GameSession.Room != null && gsp.GameSession.Room.ExpiresAt > now)
            .Select(gsp => new GetActiveGameSessionResponse
            {
                GameSessionId = gsp.GameSession.Id,
                RoomId = gsp.GameSession.RoomId,
                RoomName = gsp.GameSession.Room != null ? gsp.GameSession.Room.Name : "Unknown"
            })
            .FirstOrDefaultAsync(cancellationToken);

        return activeSession;
    }
}
