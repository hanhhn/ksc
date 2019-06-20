using Cf.Libs.Core.Infrastructure.Entity;
using Microsoft.AspNetCore.Identity;
using System;

namespace Cf.Libs.DataAccess.Entities.Account
{
    public class User : IdentityUser<int>, IEntityRoot
    {
        public DateTime LastPasswordChanged { get; set; }

        public int UserProfileId { get; set; }
        public virtual  UserProfile UserProfile { get; set; }
    }
}