using AuthService.Domain.Entities;

namespace AuthService.Application.Abstractions.Data
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmail(string email);
    }
}