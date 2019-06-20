using Cf.Libs.Core.Infrastructure.Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Cf.Libs.DataAccess.Entities.Account
{
    public class Role : IdentityRole<int>, IEntityRoot
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
