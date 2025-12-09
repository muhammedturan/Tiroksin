using MediatR;
using Tiroksin.Application.Common.DTOs;

namespace Tiroksin.Application.GameSessions.Queries.GetGameSession;

public record GetGameSessionQuery : IRequest<GetGameSessionResponse?>
{
    public Guid SessionId { get; init; }
    public Guid UserId { get; init; }
}

public record GetGameSessionResponse
{
    public string GameSessionId { get; init; } = string.Empty;
    public string RoomId { get; init; } = string.Empty; // SignalR group için
    public string Status { get; init; } = string.Empty;
    public int CurrentQuestionIndex { get; init; } = 0;
    public int? RemainingTimeSeconds { get; init; } // Kalan süre (saniye)
    public List<QuestionDto> Questions { get; init; } = new();
    public List<PlayerScoreDto> Scoreboard { get; init; } = new();
    public Dictionary<string, string?> UserAnswers { get; init; } = new();
    public List<string> FinishedPlayerIds { get; init; } = new();
    public Dictionary<string, List<GamePlayerAnswerDto>> AllPlayersAnswers { get; init; } = new();
    public List<PlayerResultDto>? Results { get; init; } = null;
}

public record QuestionDto
{
    public string Id { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public string? ImageUrl { get; init; }
    public List<OptionDto> Options { get; init; } = new();
    public string? CorrectOptionId { get; init; }
}

public record OptionDto
{
    public string Id { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public string? ImageUrl { get; init; }
    public string OptionKey { get; init; } = string.Empty;
    public bool IsCorrect { get; init; }
}

public record PlayerScoreDto
{
    public string UserId { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Avatar { get; init; } = "👤";
    public int Score { get; init; }
    public int Rank { get; init; }
    public bool IsEliminated { get; init; }
}

public record GamePlayerAnswerDto
{
    public string UserId { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Avatar { get; init; } = string.Empty;
    public string? SelectedOptionId { get; init; }
    public bool IsCorrect { get; init; }
    public int TimeSpent { get; init; }
}
