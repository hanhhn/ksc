using Cf.Libs.Core.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Cf.Libs.Core.Caching
{
    public class RedisCache : IBaseCache
    {
        private readonly IBaseCache _perRequestCache;
        private readonly IRedisConnection _connection;
        private readonly IDatabase _db;

        public RedisCache(IBaseCache perRequestCache, IRedisConnection connection, CfConfig config)
        {
            if (string.IsNullOrEmpty(config.RedisConnectionString))
                throw new Exception("Redis connection string is empty");

            _perRequestCache = perRequestCache;
            _connection = connection;
            _db = _connection.GetDatabase(config.RedisDatabaseId <= 0 ? config.RedisDatabaseId : (int)RedisDatabaseNumber.Cache);
        }
        
        protected virtual IEnumerable<RedisKey> GetKeys(EndPoint endPoint, string prefix = null)
        {
            var server = _connection.GetServer(endPoint);

            //we can use the code below (commented), but it requires administration permission - ",allowAdmin=true"
            //server.FlushDatabase();

            var keys = server.Keys(_db.Database, string.IsNullOrEmpty(prefix) ? null : $"{prefix}*");

            //we should always persist the data protection key list
            keys = keys.Where(key => !key.ToString().Equals(CachingDefaults.RedisDataProtectionKey, StringComparison.OrdinalIgnoreCase));

            return keys;
        }


        public virtual T Get<T>(string key)
        {
            //little performance workaround here:
            //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
            //this way we won't connect to Redis server many times per HTTP request (e.g. each time to load a locale or setting)
            if (_perRequestCache.IsSet(key))
                return _perRequestCache.Get(key, () => default(T), 0);

            //get serialized item from cache
            var serializedItem = _db.StringGet(key);
            if (!serializedItem.HasValue)
                return default(T);

            //deserialize item
            var item = JsonConvert.DeserializeObject<T>(serializedItem);
            if (item == null)
                return default(T);

            //set item in the per-request cache
            _perRequestCache.Set(key, item, 0);

            return item;
        }

        public virtual T Get<T>(string key, Func<T> acquire, int? cacheTime = null)
        {
            //item already is in cache, so return it
            if (IsSet(key))
                return Get<T>(key);

            //or create it using passed function
            var result = acquire();

            //and set in cache (if cache time is defined)
            if ((cacheTime ?? CachingDefaults.CacheTime) > 0)
                Set(key, result, cacheTime ?? CachingDefaults.CacheTime);

            return result;
        }

        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            //set cache time
            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            //serialize item
            var serializedItem = JsonConvert.SerializeObject(data);

            //and set it to cache
            _db.StringSet(key, serializedItem, expiresIn);
        }

        public virtual bool IsSet(string key)
        {
            //little performance workaround here:
            //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
            //this way we won't connect to Redis server many times per HTTP request (e.g. each time to load a locale or setting)
            if (_perRequestCache.IsSet(key))
                return true;

            return _db.KeyExists(key);
        }

        public virtual void Remove(string key)
        {
            //we should always persist the data protection key list
            if (key.Equals(CachingDefaults.RedisDataProtectionKey, StringComparison.OrdinalIgnoreCase))
                return;

            //remove item from caches
            _db.KeyDelete(key);
            _perRequestCache.Remove(key);
        }

        public virtual void RemoveByPrefix(string prefix)
        {
            _perRequestCache.RemoveByPrefix(prefix);

            foreach (var endPoint in _connection.GetEndPoints())
            {
                var keys = GetKeys(endPoint, prefix);

                _db.KeyDelete(keys.ToArray());
            }
        }

        public virtual void Clear()
        {
            foreach (var endPoint in _connection.GetEndPoints())
            {
                var keys = GetKeys(endPoint).ToArray();

                //we cant use _perRequestCacheManager.Clear(),
                //because HttpContext stores some server data that we should not delete
                foreach (var redisKey in keys)
                {
                    _perRequestCache.Remove(redisKey.ToString());
                }

                _db.KeyDelete(keys);
            }
        }

        public virtual void Dispose()
        {
        }
    }
}
