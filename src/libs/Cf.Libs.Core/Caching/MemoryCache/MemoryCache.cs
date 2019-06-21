using Cf.Libs.Core.Caching.BaseCache;
using Cf.Libs.Core.Caching.PerRequest;
using EasyCaching.Core;
using System;
using System.Threading.Tasks;

namespace Cf.Libs.Core.Caching.MemoryCache
{
    public class MemoryCache : IMemoryCache
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

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int? cacheTime = null)
        {
            if (cacheTime <= 0)
                return await acquire();

            var t = await _provider.GetAsync(key, acquire, TimeSpan.FromMinutes(cacheTime ?? CachingDefaults.CacheTime));
            return t.Value;
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

        public bool PerformActionWithLock(string key, TimeSpan expirationTime, Action action)
        {
            //ensure that lock is acquired
            if (_provider.Exists(key))
                return false;

            try
            {
                _provider.Set(key, key, expirationTime);

                //perform action
                action();

                return true;
            }
            finally
            {
                //release lock even if action fails
                Remove(key);
            }
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