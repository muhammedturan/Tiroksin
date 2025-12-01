using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tiroksin.Application.Rooms.Commands.CreateRoom;
using Tiroksin.Application.Rooms.Commands.JoinRoom;
using Tiroksin.Application.Rooms.Queries.GetRooms;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all active rooms
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<RoomDto>>> GetRooms(
        [FromQuery] bool? isPublic = null,
        [FromQuery] RoomStatus? status = null,
        [FromQuery] GameMode? gameMode = null)
    {
        var query = new GetRoomsQuery
        {
            IsPublic = isPublic,
            Status = status,
            GameMode = gameMode
        };

        var rooms = await _mediator.Send(query);
        return Ok(rooms);
    }

    /// <summary>
    /// Create a new room
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateRoomResponse>> CreateRoom([FromBody] CreateRoomRequest request)
    {
        var userId = GetUserIdFromToken();

        var command = new CreateRoomCommand
        {
            Name = request.Name,
            Description = request.Description,
            GameMode = request.GameMode,
            MaxPlayers = request.MaxPlayers,
            MinPlayers = request.MinPlayers,
            IsPublic = request.IsPublic,
            Password = request.Password,
            QuestionCount = request.QuestionCount,
            HostUserId = userId
        };

        var response = await _mediator.Send(command);
        return Ok(response);
    }

    /// <summary>
    /// Join a room by room code
    /// </summary>
    [HttpPost("join")]
    [Authorize]
    public async Task<ActionResult<JoinRoomResponse>> JoinRoom([FromBody] JoinRoomRequest request)
    {
        var userId = GetUserIdFromToken();

        var command = new JoinRoomCommand
        {
            RoomCode = request.RoomCode,
            Password = request.Password,
            UserId = userId
        };

        var response = await _mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    private Guid GetUserIdFromToken()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(userIdClaim!);
    }
}

// DTOs
public record CreateRoomRequest
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public GameMode GameMode { get; init; } = GameMode.Classic;
    public int MaxPlayers { get; init; } = 4;
    public int MinPlayers { get; init; } = 2;
    public bool IsPublic { get; init; } = true;
    public string? Password { get; init; }
    public int QuestionCount { get; init; } = 10;
}

public record JoinRoomRequest
{
    public string RoomCode { get; init; } = string.Empty;
    public string? Password { get; init; }
}
