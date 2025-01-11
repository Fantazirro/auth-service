namespace AuthService.Application.Abstractions.Common
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan lifeTime);
        Task RemoveAsync(string key);
        Task<bool> ContainsKey(string key);
    }
}