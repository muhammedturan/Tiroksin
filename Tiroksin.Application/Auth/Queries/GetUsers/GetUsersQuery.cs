using Tiroksin.Application.Common;
using MediatR;

namespace Tiroksin.Application.Auth.Queries.GetUsers;

public class GetUsersQuery : IRequest<Result<List<UserDto>>>
{
}

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
}
