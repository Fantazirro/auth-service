using AuthService.Domain.Entities;

namespace AuthService.Application.Abstractions.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}