namespace Tiroksin.Application.Common.DTOs;

public record PlayerResultDto
{
    public Guid UserId { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Avatar { get; init; } = "👤";
    public int Rank { get; init; }
    public int Score { get; init; }
    public int CorrectAnswers { get; init; }
    public int WrongAnswers { get; init; }
    public int UnansweredCount { get; init; }
    public int TotalTimeSpent { get; init; }
    public double AverageTimePerQuestion { get; init; }
    public int XpEarned { get; init; }
    public int NewLevel { get; init; }
    public int NewXp { get; init; }
    public bool IsWinner { get; init; }
    public List<string> AchievementsUnlocked { get; init; } = new();
}

public record PlayerAnswerDto
{
    public Guid UserId { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Avatar { get; init; } = string.Empty;
    public Guid? SelectedOptionId { get; init; }
    public bool IsCorrect { get; init; }
    public int TimeSpent { get; init; }
}
