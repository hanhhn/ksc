namespace Cf.Libs.Core.Caching.BaseCache
{
    public class CachingDefaults
    {
        public static int CacheTime => 60;
        public static string RedisDataProtectionKey => "DataProtectionKeys";
    }
}