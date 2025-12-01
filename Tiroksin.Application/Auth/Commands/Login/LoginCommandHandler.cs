using Tiroksin.Application.Common;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Application.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponse>>
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtTokenService _jwtTokenService;

    public LoginCommandHandler(ApplicationDbContext context, IJwtTokenService jwtTokenService)
    {
        _context = context;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result<AuthResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var usernameOrEmail = command.Username.ToLower();

        // Email veya username ile giriş yapılabilir
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail, cancellationToken);

        if (user == null)
            return Result<AuthResponse>.Fail("Kullanıcı bulunamadı");

        // Verify password
        if (!BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash))
            return Result<AuthResponse>.Fail("Şifre hatalı");

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
