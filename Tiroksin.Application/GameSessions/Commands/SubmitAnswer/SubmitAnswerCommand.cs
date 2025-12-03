using MediatR;

namespace Tiroksin.Application.GameSessions.Commands.SubmitAnswer;

public record SubmitAnswerCommand : IRequest<SubmitAnswerResponse>
{
    public Guid GameSessionId { get; init; }
    public Guid UserId { get; init; }
    public Guid QuestionId { get; init; }
    public Guid? SelectedOptionId { get; init; } // Null = boş bırakıldı
    public int TimeSpent { get; init; } // Saniye
}

public record SubmitAnswerResponse
{
    public bool IsCorrect { get; init; }
    public int PointsEarned { get; init; }
    public Guid? CorrectOptionId { get; init; }
    public int TotalScore { get; init; }
    public int CorrectAnswers { get; init; }
    public int WrongAnswers { get; init; }
    public bool IsEliminated { get; init; } // Survival modunda elenme durumu
    public bool IsGameFinished { get; init; } // Oyun bitmiş mi
    public string Message { get; init; } = string.Empty;
    public bool Success { get; init; }
}
