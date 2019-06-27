using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Account;

namespace Cf.Libs.DataAccess.Repository.UserProfiles
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
