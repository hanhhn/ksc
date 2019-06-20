namespace Cf.Libs.Core.Caching
{
    public class CachingDefaults
    {
        public static int CacheTime => 60;
        public static string RedisDataProtectionKey => "DataProtectionKeys";
    }
}