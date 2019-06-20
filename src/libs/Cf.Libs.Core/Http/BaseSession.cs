using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Http
{
    [Serializable]
    public class BaseSession<T> where T : class, new()
    {
        private static IHttpContextAccessor _httpContextAccessor;

        protected static T Instance;

        protected static string SessionKey;

        public static T Current
        {
            get
            {
                Instance = JsonConvert.DeserializeObject<T>(_httpContextAccessor.HttpContext.Session.GetString(SessionKey)); 
                if (Instance == null)
                {
                    Instance = new T();
                    _httpContextAccessor.HttpContext.Session.SetString(SessionKey, JsonConvert.SerializeObject(Instance));
                }
                return Instance;
            }
        }

        public virtual void Remove()
        {
            HttpContext.Current.Session.Remove(SessionKey);
        }

        public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
