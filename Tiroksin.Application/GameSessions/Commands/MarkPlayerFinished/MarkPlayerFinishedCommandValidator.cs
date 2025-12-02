using FluentValidation;

namespace Tiroksin.Application.GameSessions.Commands.MarkPlayerFinished;

public class MarkPlayerFinishedCommandValidator : AbstractValidator<MarkPlayerFinishedCommand>
{
    public MarkPlayerFinishedCommandValidator()
    {
        RuleFor(x => x.GameSessionId)
            .NotEmpty().WithMessage("Oyun oturumu kimliği gereklidir.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı kimliği gereklidir.");
    }
}
