namespace Tiroksin.Api.Settings;

/// <summary>
/// Game-related configuration settings
/// </summary>
public class GameSettings
{
    public const string SectionName = "Game";

    /// <summary>
    /// Question timeout in seconds (default: 60)
    /// </summary>
    public int QuestionTimeoutSeconds { get; set; } = 60;

    /// <summary>
    /// Buffer time added to timeout for server-side checks (default: 5)
    /// </summary>
    public int TimeoutBufferSeconds { get; set; } = 5;

    /// <summary>
    /// Default question count per game (default: 10)
    /// </summary>
    public int DefaultQuestionCount { get; set; } = 10;

    /// <summary>
    /// Minimum players required to start a game (default: 2)
    /// </summary>
    public int MinPlayers { get; set; } = 2;

    /// <summary>
    /// Maximum players per room (default: 10)
    /// </summary>
    public int MaxPlayers { get; set; } = 10;

    /// <summary>
    /// Speed bonus multiplier (percentage of base points based on remaining time)
    /// 1.0 = 100% bonus for instant answer, 0 = no speed bonus
    /// </summary>
    public double SpeedBonusMultiplier { get; set; } = 1.0;
}

/// <summary>
/// Room-related configuration settings
/// </summary>
public class RoomSettings
{
    public const string SectionName = "Room";

    /// <summary>
    /// Room expiration time in hours (default: 2)
    /// </summary>
    public int ExpirationHours { get; set; } = 2;

    /// <summary>
    /// Room cleanup interval in minutes (default: 5)
    /// </summary>
    public int CleanupIntervalMinutes { get; set; } = 5;

    /// <summary>
    /// Game timeout check interval in seconds (default: 5)
    /// </summary>
    public int TimeoutCheckIntervalSeconds { get; set; } = 5;
}
