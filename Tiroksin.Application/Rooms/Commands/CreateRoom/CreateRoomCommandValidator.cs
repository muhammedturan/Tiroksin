using FluentValidation;

namespace Tiroksin.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Oda adı gereklidir.")
            .MinimumLength(2).WithMessage("Oda adı en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Oda adı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olabilir.");

        RuleFor(x => x.MaxPlayers)
            .InclusiveBetween(2, 20).WithMessage("Maksimum oyuncu sayısı 2-20 arasında olmalıdır.");

        RuleFor(x => x.MinPlayers)
            .InclusiveBetween(1, 10).WithMessage("Minimum oyuncu sayısı 1-10 arasında olmalıdır.")
            .LessThanOrEqualTo(x => x.MaxPlayers).WithMessage("Minimum oyuncu sayısı, maksimum oyuncu sayısından fazla olamaz.");

        RuleFor(x => x.QuestionCount)
            .InclusiveBetween(5, 50).WithMessage("Soru sayısı 5-50 arasında olmalıdır.");

        RuleFor(x => x.Password)
            .MaximumLength(20).WithMessage("Oda şifresi en fazla 20 karakter olabilir.")
            .When(x => !x.IsPublic && !string.IsNullOrEmpty(x.Password));

        RuleFor(x => x.HostUserId)
            .NotEmpty().WithMessage("Host kullanıcı ID'si gereklidir.");

        RuleFor(x => x.GameMode)
            .IsInEnum().WithMessage("Geçersiz oyun modu.");
    }
}
