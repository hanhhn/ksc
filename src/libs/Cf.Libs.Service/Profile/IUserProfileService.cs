using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.DataAccess.Entities.Account;
using System.Collections;
using System.Collections.Generic;

namespace Cf.Libs.Service.Profile
{
    public interface IUserProfileService : IBaseService
    {
        int Add();
        IEnumerable<UserProfile> UserProfiles();
    }
}
