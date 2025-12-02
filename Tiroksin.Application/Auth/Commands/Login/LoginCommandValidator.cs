using FluentValidation;

namespace Tiroksin.Application.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Kullanıcı adı gereklidir.")
            .MaximumLength(30).WithMessage("Kullanıcı adı en fazla 30 karakter olabilir.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre gereklidir.")
            .MaximumLength(100).WithMessage("Şifre en fazla 100 karakter olabilir.");
    }
}
