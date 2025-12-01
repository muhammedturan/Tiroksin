using MediatR;

namespace Tiroksin.Application.Rooms.Commands.JoinRoom;

public record JoinRoomCommand : IRequest<JoinRoomResponse>
{
    public string RoomCode { get; init; } = string.Empty;
    public string? Password { get; init; }
    public Guid UserId { get; init; } // From JWT
}

public record JoinRoomResponse
{
    public Guid RoomId { get; init; }
    public string RoomCode { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public Guid HostUserId { get; init; }
    public Tiroksin.Domain.Enums.GameMode GameMode { get; init; }
    public int MaxPlayers { get; init; }
    public int MinPlayers { get; init; }
    public int QuestionCount { get; init; }
    public int TimePerQuestion { get; init; }
    public int CurrentPlayers { get; init; }
    public string Message { get; init; } = string.Empty;
    public bool Success { get; init; }
}
