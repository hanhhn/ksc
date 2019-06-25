using Cf.Ksc.DataAccess.Entities;
using Cf.Libs.DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Ksc.DataAccess.Mapping
{
    public class DepartmentConfigure : EntityTypeConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("TestDepartment");

            base.Configure(builder);
        }
    }
}