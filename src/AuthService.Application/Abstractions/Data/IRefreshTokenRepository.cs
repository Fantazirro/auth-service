using AuthService.Domain.Entities;

namespace AuthService.Application.Abstractions.Data
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
    }
}