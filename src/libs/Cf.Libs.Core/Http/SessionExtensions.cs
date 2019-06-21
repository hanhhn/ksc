using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Cf.Libs.Core.Http
{
    public static class SessionExtensions
    {
        /// <summary>
        /// Set value to Session
        /// </summary>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Get value from session
        /// </summary>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
                return default(T);

            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}