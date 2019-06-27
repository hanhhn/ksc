using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Account;
using Cf.Libs.DataAccess.Repository.UserProfiles;
using System;

namespace Cf.Libs.Service.Profile
{
    public class UserProfileService : BaseService, IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository) : base(unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
        }

        public int Count()
        {
            var t = _userProfileRepository.Add(new UserProfile()
            {
                Note = "12"
            });

            return _unitOfWork.SaveChanges();
        }
    }
}