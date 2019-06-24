using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.Context;
using Cf.Libs.DataAccess.Entities.Account;

namespace Cf.Libs.DataAccess.Repository.UserProfiles
{
    public class UserProfileRepository : BaseRepository<CfContext, UserProfile>, IUserProfileRepository
    {

    }
}
