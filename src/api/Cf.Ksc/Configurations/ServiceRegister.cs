using Cf.Ksc.DataAccess;
using Cf.Ksc.Service;
using Cf.Libs.DataAccess;
using Cf.Libs.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Ksc.Configurations
{
    public static class ServiceRegister
    {
        public static void AddServicesAndRepository(this IServiceCollection services)
        {
            services.AddCoreRepositories();
            services.AddCoreServices();
            services.AddKscRepositories();
            services.AddKscServices();
        }
    }
}