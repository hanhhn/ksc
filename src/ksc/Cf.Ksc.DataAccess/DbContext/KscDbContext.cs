using Cf.Ksc.DataAccess.Seed;
using Cf.Libs.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Cf.Ksc.DataAccess.DbContext
{
    public class KscDbContext : ApplicationDbContext
    {
        public KscDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            TablesBuilder.Build(builder);
            KscSeedDefault.Seeding(builder);
        }
    }
}