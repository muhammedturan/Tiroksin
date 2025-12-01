using Tiroksin.Application.Common;
using MediatR;

namespace Tiroksin.Application.Auth.Commands.Register;

public class RegisterCommand : IRequest<Result<AuthResponse>>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Theme { get; set; } = "dark";
}

public class AuthResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
