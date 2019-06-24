using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.DataAccess.Repository.UserProfiles;
using System;

namespace Cf.Libs.Service.Profile
{
    public class UserProfileService : BaseService, IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
