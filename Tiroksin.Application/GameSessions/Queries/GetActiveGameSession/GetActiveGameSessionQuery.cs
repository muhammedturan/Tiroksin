using MediatR;

namespace Tiroksin.Application.GameSessions.Queries.GetActiveGameSession;

public record GetActiveGameSessionQuery : IRequest<GetActiveGameSessionResponse?>
{
    public Guid UserId { get; init; }
}

public record GetActiveGameSessionResponse
{
    public Guid GameSessionId { get; init; }
    public Guid RoomId { get; init; }
    public string RoomName { get; init; } = string.Empty;
}
