using MediatR;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand : IRequest<CreateRoomResponse>
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public GameMode GameMode { get; init; } = GameMode.Classic;
    public int MaxPlayers { get; init; } = 4;
    public int MinPlayers { get; init; } = 2;
    public bool IsPublic { get; init; } = true;
    public string? Password { get; init; }

    // Game Settings
    public int QuestionCount { get; init; } = 10;

    // Host User ID (from JWT)
    public Guid HostUserId { get; init; }
}

public record CreateRoomResponse
{
    public Guid RoomId { get; init; }
    public string RoomCode { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public Guid HostUserId { get; init; }
    public GameMode GameMode { get; init; }
    public int MaxPlayers { get; init; }
    public int MinPlayers { get; init; }
    public int QuestionCount { get; init; }
    public int TimePerQuestion { get; init; }
    public string Message { get; init; } = string.Empty;
}
