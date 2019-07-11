using Cf.Ksc.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Cf.Ksc.Configurations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KscDbContext>
    {
        /// <summary>
        /// dotnet ef migrations add init -p G:\ksc\src\ksc\Cf.Ksc.DataAccess\Cf.Ksc.DataAccess.csproj
        /// dotnet ef database update
        /// </summary>
        public KscDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var builder = new DbContextOptionsBuilder<KscDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            builder.UseMySql(connectionString ?? "server=45.32.125.153;database=ksc;user=root;password=@chocon")
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

            return new KscDbContext(builder.Options);
        }
    }
}