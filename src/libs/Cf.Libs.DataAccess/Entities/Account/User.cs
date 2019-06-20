using Cf.Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.DataAccess.Entities.Account
{
    public class User : IdentityUser<int>, IEntityRoot
    {
        public DateTime LastPasswordChanged { get; set; }
    }
}
