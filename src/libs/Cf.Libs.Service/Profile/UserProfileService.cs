using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Account;
using Cf.Libs.DataAccess.Repository.UserProfiles;
using System;
using System.Collections.Generic;

namespace Cf.Libs.Service.Profile
{
    public class UserProfileService : BaseService, IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository) : base(unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
        }

        public int Add()
        {
            var user = _userProfileRepository.Add(new UserProfile
            {
                Note = DateTime.Now.ToLongDateString()
            });
            _unitOfWork.SaveChanges();
            return user.Id;
        }

        public IEnumerable<UserProfile> UserProfiles()
        {
            return _userProfileRepository.GetAll();
        }
    }
}