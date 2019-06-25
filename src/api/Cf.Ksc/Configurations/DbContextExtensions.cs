using Cf.Ksc.DataAccess.DbContext;
using Cf.Libs.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cf.Ksc.Configurations
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnectionString = configuration.GetValue<string>("DefaultConnectionString");

            services
                .AddDbContext<KscDbContext>(options => options.UseMySql(sqlConnectionString))
                .AddScoped<DbContext, KscDbContext>()
                .AddScoped<ApplicationDbContext, KscDbContext>();

            return services;
        }
    }
}
