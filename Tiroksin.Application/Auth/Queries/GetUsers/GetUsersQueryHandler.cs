using Tiroksin.Application.Common;
using Tiroksin.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Application.Auth.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<List<UserDto>>>
{
    private readonly ApplicationDbContext _context;

    public GetUsersQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<UserDto>>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        // Tüm kullanıcıları getir (AddGoal'da arama için gerekli)
        // TODO: İleride arama yapıldığında filtreleme eklenebilir
        var users = await _context.Users
            .Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                DisplayName = u.DisplayName,
                Avatar = u.Avatar
            })
            .ToListAsync(cancellationToken);

        return Result<List<UserDto>>.Ok(users);
    }
}
