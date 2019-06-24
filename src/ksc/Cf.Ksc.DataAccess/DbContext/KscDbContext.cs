using Cf.Libs.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Cf.Ksc.DataAccess.Context
{
    public class KscDbContext : ApplicationDbContext
    {
        public KscDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}