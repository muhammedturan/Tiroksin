using FluentValidation;

namespace Tiroksin.Application.Rooms.Commands.StartGame;

public class StartGameCommandValidator : AbstractValidator<StartGameCommand>
{
    public StartGameCommandValidator()
    {
        RuleFor(x => x.RoomId)
            .NotEmpty().WithMessage("Oda kimliği gereklidir.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı kimliği gereklidir.");
    }
}
