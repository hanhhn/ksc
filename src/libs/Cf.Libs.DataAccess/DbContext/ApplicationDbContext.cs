using Cf.Libs.Core.Infrastructure.Context;
using Cf.Libs.DataAccess.Entities.Account;
using Cf.Libs.DataAccess.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cf.Libs.DataAccess.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IDbContext
    {
        private const string SchemaDefault = "cf";

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.HasDefaultSchema(SchemaDefault);

            base.OnModelCreating(builder);
            TablesBuilder.Build(builder);
            CfSeedDefault.Seeding(builder);
        }
    }
}