using Cf.Libs.Core.Caching.BaseCache;
using Cf.Libs.Core.Caching.PerRequest;
using Cf.Libs.Core.ComponentModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Cf.Libs.Core.Caching
{
    /// <summary>
    /// Represents a manager for caching during an HTTP request (short term caching)
    /// </summary>
    public partial class PerRequestCache : IRequestCache
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ReaderWriterLockSlim _locker;

        public PerRequestCache(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _locker = new ReaderWriterLockSlim();
        }

        protected virtual IDictionary<object, object> GetItems()
        {
            if (_httpContextAccessor.HttpContext.Items == null)
                return new Dictionary<object, object>();

            return _httpContextAccessor.HttpContext.Items;
        }

        public virtual T Get<T>(string key, Func<T> acquire, int? cacheTime = null)
        {
            IDictionary<object, object> items;

            using (new ReaderWriteLock(_locker, ReaderWriteLockType.Read))
            {
                items = GetItems();
                if (items == null)
                    return acquire();

                //item already is in cache, so return it
                if (items[key] != null)
                    return (T)items[key];
            }

            //or create it using passed function
            var result = acquire();

            if (result == null || (cacheTime ?? CachingDefaults.CacheTime) <= 0)
                return result;

            //and set in cache (if cache time is defined)
            using (new ReaderWriteLock(_locker))
            {
                items[key] = result;
            }

            return result;
        }

        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            using (new ReaderWriteLock(_locker))
            {
                var items = GetItems();
                if (items == null)
                    return;

                items[key] = data;
            }
        }

        public virtual bool IsSet(string key)
        {
            using (new ReaderWriteLock(_locker, ReaderWriteLockType.Read))
            {
                var items = GetItems();
                return items[key] != null;
            }
        }

        public virtual void Remove(string key)
        {
            using (new ReaderWriteLock(_locker))
            {
                var items = GetItems();
                items.Remove(key);
            }
        }

        public virtual void RemoveByPrefix(string prefix)
        {
            using (new ReaderWriteLock(_locker, ReaderWriteLockType.UpgradeableRead))
            {
                var items = GetItems();
                if (items == null)
                    return;

                //get cache keys that matches pattern
                Regex regex = new Regex(prefix, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var matchesKeys = items.Keys.Select(p => p.ToString()).Where(key => regex.IsMatch(key)).ToList();

                if (!matchesKeys.Any())
                    return;

                using (new ReaderWriteLock(_locker))
                {
                    //remove matching values
                    foreach (var key in matchesKeys)
                    {
                        items.Remove(key);
                    }
                }
            }
        }

        public virtual void Clear()
        {
            using (new ReaderWriteLock(_locker))
            {
                var items = GetItems();
                items.Clear();
            }
        }

        public virtual void Dispose()
        {
            //nothing special
        }
    }
}