using Cf.Libs.Service.Profile;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Libs.Service
{
    public static class CfServiceRegister
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IUserProfileService, UserProfileService>();
        }
    }
}
