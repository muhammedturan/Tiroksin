using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiroksin.Domain.Entities;
using Tiroksin.Domain.Enums;
using Tiroksin.Infrastructure.Data;

namespace Tiroksin.Application.Rooms.Commands.JoinRoom;

public class JoinRoomCommandHandler : IRequestHandler<JoinRoomCommand, JoinRoomResponse>
{
    private readonly ApplicationDbContext _context;

    public JoinRoomCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<JoinRoomResponse> Handle(JoinRoomCommand request, CancellationToken cancellationToken)
    {
        // Find room by code
        var room = await _context.Rooms
            .Include(r => r.Players)
            .FirstOrDefaultAsync(r => r.RoomCode == request.RoomCode.ToUpper(), cancellationToken);

        if (room == null)
        {
            return new JoinRoomResponse
            {
                Success = false,
                Message = "Oda bulunamadı! 🔍"
            };
        }

        // Check if room is full
        var currentPlayerCount = room.Players.Count(p => p.LeftAt == null);
        if (currentPlayerCount >= room.MaxPlayers)
        {
            return new JoinRoomResponse
            {
                Success = false,
                Message = "Oda dolu! 🚫"
            };
        }

        // Check if game already started
        if (room.Status == RoomStatus.InProgress)
        {
            return new JoinRoomResponse
            {
                Success = false,
                Message = "Oyun zaten başladı! ⏳"
            };
        }

        // Check if user already in room
        var existingPlayer = room.Players
            .FirstOrDefault(p => p.UserId == request.UserId && p.LeftAt == null);

        if (existingPlayer != null)
        {
            return new JoinRoomResponse
            {
                RoomId = room.Id,
                RoomCode = room.RoomCode,
                Name = room.Name,
                HostUserId = room.HostUserId,
                GameMode = GameMode.Survival, // Always elimination
                MaxPlayers = room.MaxPlayers,
                MinPlayers = room.MinPlayers,
                QuestionCount = room.QuestionCount,
                TimePerQuestion = 60, // Always 60 seconds
                CurrentPlayers = currentPlayerCount,
                Success = true,
                Message = "Zaten odadasınız! ✅"
            };
        }

        // Check password if protected
        if (room.IsPasswordProtected)
        {
            if (string.IsNullOrEmpty(request.Password))
            {
                return new JoinRoomResponse
                {
                    Success = false,
                    Message = "Bu oda şifreli! 🔒"
                };
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, room.PasswordHash))
            {
                return new JoinRoomResponse
                {
                    Success = false,
                    Message = "Şifre yanlış! ❌"
                };
            }
        }

        // Add player to room (everyone is automatically ready)
        var roomPlayer = new RoomPlayer
        {
            Id = Guid.NewGuid(),
            RoomId = room.Id,
            UserId = request.UserId,
            Status = PlayerStatus.Waiting,
            IsReady = true, // Everyone is automatically ready
            JoinedAt = DateTime.UtcNow
        };

        _context.RoomPlayers.Add(roomPlayer);
        await _context.SaveChangesAsync(cancellationToken);

        return new JoinRoomResponse
        {
            RoomId = room.Id,
            RoomCode = room.RoomCode,
            Name = room.Name,
            HostUserId = room.HostUserId,
            GameMode = GameMode.Survival, // Always elimination
            MaxPlayers = room.MaxPlayers,
            MinPlayers = room.MinPlayers,
            QuestionCount = room.QuestionCount,
            TimePerQuestion = 60, // Always 60 seconds
            CurrentPlayers = currentPlayerCount + 1,
            Success = true,
            Message = "Odaya katıldınız! 🎮"
        };
    }
}
