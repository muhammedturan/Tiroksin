using MediatR;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Application.Rooms.Queries.GetRooms;

public record GetRoomsQuery : IRequest<List<RoomDto>>
{
    public bool? IsPublic { get; init; }
    public RoomStatus? Status { get; init; }
    public GameMode? GameMode { get; init; }
}

public record RoomDto
{
    public Guid Id { get; init; }
    public string RoomCode { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public GameMode GameMode { get; init; }
    public RoomStatus Status { get; init; }
    public int CurrentPlayers { get; init; }
    public int MaxPlayers { get; init; }
    public int MinPlayers { get; init; }
    public bool IsPublic { get; init; }
    public bool IsPasswordProtected { get; init; }
    public int QuestionCount { get; init; }
    public int TimePerQuestion { get; init; }
    public string? CategoryName { get; init; }
    public string? SubjectName { get; init; }
    public string HostUsername { get; init; } = string.Empty;
    public string HostAvatar { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}
