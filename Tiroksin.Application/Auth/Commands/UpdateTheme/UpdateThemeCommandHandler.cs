using Tiroksin.Application.Common;
using Tiroksin.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Application.Auth.Commands.UpdateTheme;

public class UpdateThemeCommandHandler : IRequestHandler<UpdateThemeCommand, Result<bool>>
{
    private readonly ApplicationDbContext _context;

    public UpdateThemeCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(UpdateThemeCommand command, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == command.UserId, cancellationToken);

        if (user == null)
            return Result<bool>.Fail("Kullanici bulunamadi");

        // Validate theme value
        if (command.Theme != "dark" && command.Theme != "light")
            return Result<bool>.Fail("Gecersiz tema degeri");

        user.Theme = command.Theme;
        await _context.SaveChangesAsync(cancellationToken);

        return Result<bool>.Ok(true);
    }
}
