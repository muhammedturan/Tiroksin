using MediatR;

namespace Tiroksin.Application.GameSessions.Queries.GetGameSessionPlayers;

public record GetGameSessionPlayersQuery : IRequest<List<GameSessionPlayerDto>>
{
    public Guid GameSessionId { get; init; }
}

public record GameSessionPlayerDto
{
    public string UserId { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Avatar { get; init; } = "👤";
    public int Score { get; init; } = 0;
    public bool IsEliminated { get; init; } = false;
}
