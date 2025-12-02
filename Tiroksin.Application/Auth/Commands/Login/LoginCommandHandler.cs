using Tiroksin.Application.Common;
using Tiroksin.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Application.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IJwtTokenService _jwtTokenService;

    public LoginCommandHandler(IApplicationDbContext context, IJwtTokenService jwtTokenService)
    {
        _context = context;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result<AuthResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var usernameOrEmail = command.Username.ToLower().Trim();

        // Email veya username ile giriş yapılabilir
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username.ToLower() == usernameOrEmail || u.Email.ToLower() == usernameOrEmail, cancellationToken);

        // Use constant-time password verification to prevent timing attacks
        // Always verify password even if user not found (prevents user enumeration)
        var passwordHash = user?.PasswordHash ?? "$2a$11$InvalidHashForTimingAttackPrevention";
        var isPasswordValid = BCrypt.Net.BCrypt.Verify(command.Password, passwordHash);

        // Generic error message to prevent user enumeration
        if (user == null || !isPasswordValid)
            return Result<AuthResponse>.Fail("Kullanıcı adı veya şifre hatalı");

        var token = _jwtTokenService.GenerateToken(user);

        var response = new AuthResponse
        {
            Id = user.Id,
            Username = user.Username,
            DisplayName = user.DisplayName,
            Avatar = user.Avatar,
            Theme = user.Theme,
            Token = token
        };

        return Result<AuthResponse>.Ok(response);
    }
}
