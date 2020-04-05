using Microsoft.Extensions.Caching.Memory;
using webBeta.NSerializer.Base;

namespace webBeta.NSerializer.AspNetCore
{
    public class MemoryCache : ICache
    {
        private readonly IMemoryCache _cache;

        public MemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string Get(string key)
        {
            return _cache.Get<string>(key);
        }

        public void Set(string key, string content)
        {
            _cache.Set(key, content);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}