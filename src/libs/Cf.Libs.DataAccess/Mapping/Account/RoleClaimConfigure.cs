using Cf.Libs.DataAccess.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Account
{
    public class RoleClaimConfigure : EntityTypeConfiguration<RoleClaim>
    {
        public override void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(RoleClaim));
        }
    }
}