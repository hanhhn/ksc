using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Accounts;
using System.Threading.Tasks;

namespace Cf.Libs.Service.Profile
{
    public interface IAccountService : IBaseService
    {
        Task<bool> SigninAsyn(SigninDto model);
        Task<bool> SignupAsyn(SignupDto model);
    }
}