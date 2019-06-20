using Cf.Libs.Core.Infrastructure.Entity;
using Microsoft.AspNetCore.Identity;

namespace Cf.Libs.DataAccess.Entities.Account
{
    public class UserClaim : IdentityUserClaim<int>, IEntityRoot
    {
    }
}
