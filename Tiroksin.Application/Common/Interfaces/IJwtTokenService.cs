using Tiroksin.Domain.Entities;

namespace Tiroksin.Application.Common.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
