namespace AuthService.Application.Abstractions.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}