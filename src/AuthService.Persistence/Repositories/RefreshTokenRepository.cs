using AuthService.Application.Abstractions.Data;
using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AuthDbContext dbContext) : base(dbContext) { }

        public new async Task<RefreshToken?> GetById(Guid id)
        {
            return await _dbContext.RefreshTokens.Include(token => token.User).FirstAsync(token => token.Id == id);
        }
    }
}