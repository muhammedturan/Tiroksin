using FluentValidation;

namespace Tiroksin.Application.GameSessions.Commands.FinishGame;

public class FinishGameCommandValidator : AbstractValidator<FinishGameCommand>
{
    public FinishGameCommandValidator()
    {
        RuleFor(x => x.GameSessionId)
            .NotEmpty().WithMessage("Oyun oturumu kimliği gereklidir.");
    }
}
