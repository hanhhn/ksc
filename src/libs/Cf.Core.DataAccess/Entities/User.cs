using Cf.Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Core.DataAccess.Entities
{
    public class User : IdentityUser<int>, IEntityRoot
    {
        public DateTime LastPasswordChanged { get; set; }
    }
}
