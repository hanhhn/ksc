using Cf.Libs.Core.Caching.BaseCache;

namespace Cf.Libs.Core.Caching.PerRequest
{
    public interface IMemoryCache : IStaticCache, ILocker
    {
    }
}
