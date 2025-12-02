using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Application.Common.Interfaces;

namespace Tiroksin.Application.GameSessions.Queries.GetGameSessionPlayers;

public class GetGameSessionPlayersQueryHandler : IRequestHandler<GetGameSessionPlayersQuery, List<GameSessionPlayerDto>>
{
    private readonly IApplicationDbContext _context;

    public GetGameSessionPlayersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GameSessionPlayerDto>> Handle(GetGameSessionPlayersQuery request, CancellationToken cancellationToken)
    {
        var players = await _context.GameSessionPlayers
            .Include(p => p.User)
            .Where(p => p.GameSessionId == request.GameSessionId)
            .Select(p => new GameSessionPlayerDto
            {
                UserId = p.UserId.ToString(),
                Username = p.User.Username,
                Avatar = p.User.Avatar ?? "👤",
                Score = 0,
                IsEliminated = false
            })
            .ToListAsync(cancellationToken);

        return players;
    }
}
