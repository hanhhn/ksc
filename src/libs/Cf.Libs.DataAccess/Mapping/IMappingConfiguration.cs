using Microsoft.EntityFrameworkCore;

namespace Cf.Libs.DataAccess.Mapping
{
    public partial interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
