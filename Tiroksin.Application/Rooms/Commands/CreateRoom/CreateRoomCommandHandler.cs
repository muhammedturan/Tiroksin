using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Domain.Entities;
using Tiroksin.Domain.Enums;

namespace Tiroksin.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, CreateRoomResponse>
{
    private readonly IApplicationDbContext _context;

    public CreateRoomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateRoomResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        // Generate unique room code
        var roomCode = await GenerateUniqueRoomCodeAsync(cancellationToken);

        // Hash password if provided
        string? passwordHash = null;
        if (!string.IsNullOrEmpty(request.Password))
        {
            passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        }

        // Create room (Elimination mode only, 60 seconds per question)
        var room = new Room
        {
            Id = Guid.NewGuid(),
            RoomCode = roomCode,
            Name = request.Name,
            Description = request.Description,
            Status = RoomStatus.Waiting,
            MaxPlayers = request.MaxPlayers,
            MinPlayers = request.MinPlayers,
            IsPublic = request.IsPublic,
            IsPasswordProtected = !string.IsNullOrEmpty(request.Password),
            PasswordHash = passwordHash,
            QuestionCount = request.QuestionCount,
            HostUserId = request.HostUserId,
            CreatedAt = DateTime.UtcNow
        };

        _context.Rooms.Add(room);

        // Add host as first player (everyone is automatically ready)
        var roomPlayer = new RoomPlayer
        {
            Id = Guid.NewGuid(),
            RoomId = room.Id,
            UserId = request.HostUserId,
            Status = PlayerStatus.Waiting,
            IsReady = true, // Everyone is automatically ready
            JoinedAt = DateTime.UtcNow
        };

        _context.RoomPlayers.Add(roomPlayer);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateRoomResponse
        {
            RoomId = room.Id,
            RoomCode = room.RoomCode,
            Name = room.Name,
            HostUserId = room.HostUserId,
            GameMode = GameMode.Survival, // Always elimination mode
            MaxPlayers = room.MaxPlayers,
            MinPlayers = room.MinPlayers,
            QuestionCount = room.QuestionCount,
            TimePerQuestion = 60, // Always 60 seconds
            Message = "Oda başarıyla oluşturuldu! 🎮"
        };
    }

    private async Task<string> GenerateUniqueRoomCodeAsync(CancellationToken cancellationToken)
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"; // Removed confusing chars (I, O, 0, 1)
        var random = new Random();

        while (true)
        {
            var code = new string(Enumerable.Range(0, 6)
                .Select(_ => chars[random.Next(chars.Length)])
                .ToArray());

            // Check if code already exists
            var exists = await _context.Rooms.AnyAsync(r => r.RoomCode == code, cancellationToken);
            if (!exists)
            {
                return code;
            }
        }
    }
}
