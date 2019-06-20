using System;

namespace Cf.Libs.Core.Caching
{
    public interface IBaseCache : IDisposable
    {
        T Get<T>(string key, Func<T> acquire, int? cacheTime = null);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        void Remove(string key);
        void RemoveByPrefix(string prefix);
        void Clear();
    }
}