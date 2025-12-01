using MediatR;

namespace Tiroksin.Application.GameSessions.Commands.FinishGame;

public record FinishGameCommand : IRequest<FinishGameResponse>
{
    public Guid GameSessionId { get; init; }
}

public record FinishGameResponse
{
    public List<PlayerResultDto> Results { get; init; } = new();
    public Dictionary<Guid, List<PlayerAnswerDto>> AllPlayersAnswers { get; init; } = new();
    public string Message { get; init; } = string.Empty;
    public bool Success { get; init; }
}

public record PlayerResultDto
{
    public Guid UserId { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Avatar { get; init; } = string.Empty;
    public int Rank { get; init; }
    public int Score { get; init; }
    public int CorrectAnswers { get; init; }
    public int WrongAnswers { get; init; }
    public int UnansweredCount { get; init; }
    public int TotalTimeSpent { get; init; }
    public int AverageTimePerQuestion { get; init; }
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
