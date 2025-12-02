using FluentValidation;

namespace Tiroksin.Application.Rooms.Commands.JoinRoom;

public class JoinRoomCommandValidator : AbstractValidator<JoinRoomCommand>
{
    public JoinRoomCommandValidator()
    {
        RuleFor(x => x.RoomCode)
            .NotEmpty().WithMessage("Oda kodu gereklidir.")
            .Length(6).WithMessage("Oda kodu 6 karakter olmalıdır.")
            .Matches("^[A-Z0-9]+$").WithMessage("Oda kodu sadece büyük harf ve rakam içerebilir.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı kimliği gereklidir.");

        RuleFor(x => x.Password)
            .MaximumLength(50).WithMessage("Şifre en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Password));
    }
}
