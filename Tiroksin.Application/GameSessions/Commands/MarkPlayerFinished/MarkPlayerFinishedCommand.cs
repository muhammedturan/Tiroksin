using MediatR;

namespace Tiroksin.Application.GameSessions.Commands.MarkPlayerFinished;

public record MarkPlayerFinishedCommand : IRequest<MarkPlayerFinishedResponse>
{
    public Guid GameSessionId { get; init; }
    public Guid UserId { get; init; }
}

public record MarkPlayerFinishedResponse
{
    public string Message { get; init; } = string.Empty;
    public bool Success { get; init; }
    public bool AllPlayersFinished { get; init; }
    public int TotalPlayers { get; init; }
    public int FinishedPlayers { get; init; }
}
