using Cf.Ksc.DataAccess.Entities;
using Cf.Libs.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Cf.Ksc.DataAccess.DbContext
{
    public class KscDbContext : ApplicationDbContext
    {
        public KscDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            TablesBuilder.Build(builder);

            base.OnModelCreating(builder);
        }
    }
}