using Cf.Ksc.DataAccess.DbContext;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cf.Ksc.Configurations
{
    public static class DbContextExtensions
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnectionString = "server=10.0.75.1;database=ksc;user=root;password=@chocon";

            services
                .AddDbContext<KscDbContext>(options => options.UseMySql(sqlConnectionString))
                .AddScoped<ApplicationDbContext, KscDbContext>()
                .AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
        }
    }
}