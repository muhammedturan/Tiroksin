using MediatR;
using Tiroksin.Application.Common.DTOs;

namespace Tiroksin.Application.GameSessions.Commands.FinishGame;

public record FinishGameCommand : IRequest<FinishGameResponse>
{
    public Guid GameSessionId { get; init; }
}

public record FinishGameResponse
{
    public List<PlayerResultDto> Results { get; init; } = new();
    public Dictionary<Guid, List<PlayerAnswerDto>> AllPlayersAnswers { get; init; } = new();
    public string Message { get; init; } = string.Empty;
    public bool Success { get; init; }
}
