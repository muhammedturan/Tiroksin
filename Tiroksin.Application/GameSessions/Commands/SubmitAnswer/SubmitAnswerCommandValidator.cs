using FluentValidation;

namespace Tiroksin.Application.GameSessions.Commands.SubmitAnswer;

public class SubmitAnswerCommandValidator : AbstractValidator<SubmitAnswerCommand>
{
    public SubmitAnswerCommandValidator()
    {
        RuleFor(x => x.GameSessionId)
            .NotEmpty().WithMessage("Oyun oturumu kimliği gereklidir.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı kimliği gereklidir.");

        RuleFor(x => x.QuestionId)
            .NotEmpty().WithMessage("Soru kimliği gereklidir.");

        // TimeSpent is now calculated by backend from QuestionStartedAt
        // Client-provided value is only used as fallback, so we just ensure it's not negative
        RuleFor(x => x.TimeSpent)
            .GreaterThanOrEqualTo(0).WithMessage("Geçen süre negatif olamaz.");
    }
}
