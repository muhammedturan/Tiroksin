using MediatR;

namespace Tiroksin.Application.Rooms.Commands.StartGame;

public record StartGameCommand : IRequest<StartGameResponse>
{
    public Guid RoomId { get; init; }
    public Guid UserId { get; init; } // Must be host
}

public record StartGameResponse
{
    public Guid GameSessionId { get; init; }
    public List<GameQuestionDto> Questions { get; init; } = new();
    public string Message { get; init; } = string.Empty;
    public bool Success { get; init; }
}

public record GameQuestionDto
{
    public Guid Id { get; init; }
    public string Text { get; init; } = string.Empty;
    public string? ImageUrl { get; init; }
    public int Points { get; init; }
    public List<GameOptionDto> Options { get; init; } = new();
}

public record GameOptionDto
{
    public Guid Id { get; init; }
    public string OptionKey { get; init; } = string.Empty; // A, B, C, D, E
    public string Text { get; init; } = string.Empty;
    public string? ImageUrl { get; init; }
}
