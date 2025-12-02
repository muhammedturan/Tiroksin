using Microsoft.EntityFrameworkCore;
using Tiroksin.Domain.Entities;

namespace Tiroksin.Application.Common.Interfaces;

/// <summary>
/// Application layer abstraction for database context.
/// Implemented by Infrastructure layer.
/// </summary>
public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<UserStats> UserStats { get; }
    DbSet<Room> Rooms { get; }
    DbSet<RoomPlayer> RoomPlayers { get; }
    DbSet<Question> Questions { get; }
    DbSet<QuestionOption> QuestionOptions { get; }
    DbSet<GameSession> GameSessions { get; }
    DbSet<GameSessionPlayer> GameSessionPlayers { get; }
    DbSet<GameAnswer> GameAnswers { get; }
    DbSet<ParameterDefinition> ParameterDefinitions { get; }
    DbSet<ParameterValue> ParameterValues { get; }
    DbSet<Achievement> Achievements { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
