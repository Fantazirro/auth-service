using AuthService.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AuthDbContext _dbContext;

        public GenericRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            await _dbContext.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}