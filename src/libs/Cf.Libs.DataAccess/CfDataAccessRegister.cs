using Cf.Libs.DataAccess.Repository.UserProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Libs.DataAccess
{
    public static class CfDataAccessRegister
    {
        public static void AddCoreRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
        }
    }
}
