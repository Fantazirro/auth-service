using AuthService.Application.Abstractions.Data;
using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence
{
    public class AuthDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public async Task BeginTransaction()
        {
            await BeginTransaction();
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}