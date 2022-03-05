
using Microsoft.Extensions.Caching.Memory;

namespace SharedKernal.Middlewares.MemoryCache
{
    public class MemoryCacheService : IMemoryCacheService
    {

        public IMemoryCache MemoryCache { get; set; }

        private readonly MemoryCacheEntryOptions CacheExpirationOptions = new MemoryCacheEntryOptions
        {
            //AbsoluteExpiration = DateTime.Now.AddMinutes(30),
            Priority = CacheItemPriority.High
        };


        public TValue Get<TValue>(string key)
        {
            var isInCache = MemoryCache.TryGetValue<TValue>(key: key, value: out TValue result);
            return result;
        }

        public void AddOrUpdate<TValue>(string key, TValue value)
        {
            MemoryCache.Set<TValue>(key: key, value: value, options: CacheExpirationOptions);
        }

        public void Remove(string key)
        {
            MemoryCache.Remove(key: key);
        }
    }
}
