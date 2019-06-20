using Cf.Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.DataAccess.Entities.Account
{
    public class UserRole : IdentityUserRole<int>, IEntityRoot
    {
    }
}
