using Cf.Libs.Core.Infrastructure.Entity;

namespace Cf.Ksc.DataAccess.Entities
{
    public class Department : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
