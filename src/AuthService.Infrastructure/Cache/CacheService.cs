using AuthService.Application.Abstractions.Common;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace AuthService.Infrastructure.Cache
{
    public class CacheService(IDistributedCache cache) : ICacheService
    {
        public async Task<T> GetAsync<T>(string key)
        {
            var valueString = await cache.GetStringAsync(key);
            if (valueString is null) throw new ArgumentException($"Entry with key \"{key}\" doesn't exists");

            var value = JsonSerializer.Deserialize<T>(valueString);
            if (value is null) throw new ArgumentException("Incorrect generic type");

            return value;
        }

        public async Task RemoveAsync(string key)
        {
            await cache.RemoveAsync(key);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan lifeTime)
        {
            var valueString = JsonSerializer.Serialize(value);

            await cache.SetStringAsync(key, valueString, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = lifeTime
            });
        }
    }
}