using EasyCaching.Core;
using System;

namespace Cf.Libs.Core.Caching
{
    public class MemoryCache : IBaseCache
    {
        private readonly IEasyCachingProvider _provider;

        public MemoryCache(IEasyCachingProvider provider)
        {
            _provider = provider;
        }

        public T Get<T>(string key, Func<T> acquire, int? cacheTime = null)
        {
            if (cacheTime <= 0)
                return acquire();

            return _provider.Get(key, acquire, TimeSpan.FromMinutes(cacheTime ?? CachingDefaults.CacheTime))
                .Value;
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (cacheTime <= 0)
                return;

            _provider.Set(key, data, TimeSpan.FromMinutes(cacheTime));
        }

        public bool IsSet(string key)
        {
            return _provider.Exists(key);
        }

        public void Remove(string key)
        {
            _provider.Remove(key);
        }

        public void RemoveByPrefix(string prefix)
        {
            _provider.RemoveByPrefix(prefix);
        }

        public void Clear()
        {
            _provider.Flush();
        }

        public virtual void Dispose()
        {

        }
    }
}
