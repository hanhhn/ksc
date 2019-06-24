using Cf.Libs.Service.Profile;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Libs.Service
{
    public static class CfServiceBuilder
    {
        public static void AddCfServices(this IServiceCollection services)
        {
            services.AddTransient<IUserProfileService, UserProfileService>();
        }
    }
}
