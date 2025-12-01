using Tiroksin.Core.BaseClasses;

namespace Tiroksin.Domain.Entities;

public class User : AuditEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Avatar { get; set; } = "👤";
    public string Theme { get; set; } = "dark";

    // Navigation Properties
    public virtual ICollection<Room> HostedRooms { get; set; } = new List<Room>();
    public virtual ICollection<RoomPlayer> RoomPlayers { get; set; } = new List<RoomPlayer>();
    public virtual ICollection<GameSessionPlayer> GameSessionPlayers { get; set; } = new List<GameSessionPlayer>();
    public virtual ICollection<GameAnswer> GameAnswers { get; set; } = new List<GameAnswer>();
    public virtual UserStats? Stats { get; set; }
    public virtual ICollection<UserAchievement> Achievements { get; set; } = new List<UserAchievement>();
}
