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

        RuleFor(x => x.TimeSpent)
            .GreaterThanOrEqualTo(0).WithMessage("Geçen süre negatif olamaz.")
            .LessThanOrEqualTo(120).WithMessage("Geçen süre 120 saniyeyi aşamaz.");
    }
}
