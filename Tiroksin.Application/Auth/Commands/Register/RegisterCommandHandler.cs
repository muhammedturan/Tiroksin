using Tiroksin.Application.Common;
using Tiroksin.Application.Common.Interfaces;
using Tiroksin.Domain.Entities;
using Tiroksin.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Application.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthResponse>>
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtTokenService _jwtTokenService;

    public RegisterCommandHandler(ApplicationDbContext context, IJwtTokenService jwtTokenService)
    {
        _context = context;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result<AuthResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // Check if username exists
        var usernameExists = await _context.Users
            .AnyAsync(u => u.Username == command.Username.ToLower(), cancellationToken);

        if (usernameExists)
            return Result<AuthResponse>.Fail("Bu kullanıcı adı zaten alınmış!");

        // Email required
        var email = command.Email.ToLower();

        // Check if email exists
        var emailExists = await _context.Users
            .AnyAsync(u => u.Email == email, cancellationToken);

        if (emailExists)
            return Result<AuthResponse>.Fail("Bu email adresi zaten kullanılıyor!");

        // Hash password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);

        var user = new User
        {
            Username = command.Username.ToLower(),
            Email = email,
            DisplayName = command.DisplayName,
            PasswordHash = passwordHash,
            Avatar = "👤", // Default avatar
            Theme = string.IsNullOrEmpty(command.Theme) ? "dark" : command.Theme
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

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
