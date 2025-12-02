using FluentValidation;

namespace Tiroksin.Application.Auth.Commands.UpdateTheme;

public class UpdateThemeCommandValidator : AbstractValidator<UpdateThemeCommand>
{
    private static readonly string[] ValidThemes = { "dark", "light" };

    public UpdateThemeCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı kimliği gereklidir.");

        RuleFor(x => x.Theme)
            .NotEmpty().WithMessage("Tema gereklidir.")
            .Must(theme => ValidThemes.Contains(theme.ToLower()))
            .WithMessage("Tema 'dark' veya 'light' olmalıdır.");
    }
}
