using Tiroksin.Application.Common;
using MediatR;

namespace Tiroksin.Application.Auth.Commands.UpdateTheme;

public class UpdateThemeCommand : IRequest<Result<bool>>
{
    public Guid UserId { get; set; }
    public string Theme { get; set; } = string.Empty;
}
