using Cf.Libs.Service.Email;
using Cf.Libs.Service.Profile;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Libs.Service
{
    public static class CfServiceRegister
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IEmailSender, EmailSenderService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
        }
    }
}
