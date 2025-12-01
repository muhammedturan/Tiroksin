using Tiroksin.Domain.Entities;
using Tiroksin.Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Core entities
    public DbSet<User> Users { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }

    // Multiplayer game entities (Elimination mode only)
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomPlayer> RoomPlayers { get; set; }
    public DbSet<GameSession> GameSessions { get; set; }
    public DbSet<GameSessionPlayer> GameSessionPlayers { get; set; }
    public DbSet<GameAnswer> GameAnswers { get; set; }

    // Gamification entities
    public DbSet<UserStats> UserStats { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<UserAchievement> UserAchievements { get; set; }

    // Generic parameter system
    public DbSet<ParameterDefinition> ParameterDefinitions { get; set; }
    public DbSet<ParameterValue> ParameterValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations from assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Configure Room relationships
        modelBuilder.Entity<Room>()
            .HasOne(r => r.Host)
            .WithMany(u => u.HostedRooms)
            .HasForeignKey(r => r.HostUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Room>()
            .HasIndex(r => r.RoomCode)
            .IsUnique();

        // Configure RoomPlayer relationships
        modelBuilder.Entity<RoomPlayer>()
            .HasOne(rp => rp.Room)
            .WithMany(r => r.Players)
            .HasForeignKey(rp => rp.RoomId);

        modelBuilder.Entity<RoomPlayer>()
            .HasOne(rp => rp.User)
            .WithMany(u => u.RoomPlayers)
            .HasForeignKey(rp => rp.UserId);

        // Configure UserStats - One to One with User
        modelBuilder.Entity<UserStats>()
            .HasOne(us => us.User)
            .WithOne(u => u.Stats)
            .HasForeignKey<UserStats>(us => us.UserId);

        // Configure Achievement Code as unique
        modelBuilder.Entity<Achievement>()
            .HasIndex(a => a.Code)
            .IsUnique();

        // Configure UserAchievement relationships
        modelBuilder.Entity<UserAchievement>()
            .HasOne(ua => ua.User)
            .WithMany(u => u.Achievements)
            .HasForeignKey(ua => ua.UserId);

        modelBuilder.Entity<UserAchievement>()
            .HasOne(ua => ua.Achievement)
            .WithMany(a => a.UserAchievements)
            .HasForeignKey(ua => ua.AchievementId);

        // Configure ParameterDefinition - unique key
        modelBuilder.Entity<ParameterDefinition>()
            .HasIndex(pd => pd.Key)
            .IsUnique();

        // Configure ParameterValue relationships
        modelBuilder.Entity<ParameterValue>()
            .HasOne(pv => pv.ParameterDefinition)
            .WithMany(pd => pd.Values)
            .HasForeignKey(pv => pv.ParameterDefinitionId);

        // Unique constraint: same value cannot exist twice for same definition
        modelBuilder.Entity<ParameterValue>()
            .HasIndex(pv => new { pv.ParameterDefinitionId, pv.Value })
            .IsUnique();

        // Seed data
        DataSeeder.SeedUsers(modelBuilder);
        DataSeeder.SeedParameterDefinitions(modelBuilder);
        DataSeeder.SeedParameterValues(modelBuilder);
        DataSeeder.SeedQuestions(modelBuilder);
        DataSeeder.SeedQuestionOptions(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is Tiroksin.Core.BaseClasses.AuditEntity &&
                       (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var auditEntity = (Tiroksin.Core.BaseClasses.AuditEntity)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                auditEntity.CreatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                auditEntity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
