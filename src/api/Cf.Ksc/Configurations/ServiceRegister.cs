using Cf.Ksc.Service;
using Cf.Libs.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cf.Ksc.Configurations
{
    public class ServiceRegister
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddCfServices();
            services.AddKscServices();
        }
    }
}
