using AuthService.Application.Abstractions.Data;
using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence
{
    public class AuthDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }

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