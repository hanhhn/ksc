using Cf.Libs.DataAccess.Repository.UserProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Libs.DataAccess
{
    public static class CfDataAccessBuilder
    {
        public static void AddCfRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
        }
    }
}
