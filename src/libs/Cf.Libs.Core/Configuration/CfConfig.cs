using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Configuration
{
    public class CfConfig
    {
        public string RedisConnectionString { get; set; }
        public int RedisDatabaseId { get; set; }
    }
}
