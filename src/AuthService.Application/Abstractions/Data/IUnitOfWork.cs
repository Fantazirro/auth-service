namespace AuthService.Application.Abstractions.Data
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();
        Task Commit();
    }
}