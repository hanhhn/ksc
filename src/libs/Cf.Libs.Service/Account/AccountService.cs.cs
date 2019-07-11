using AutoMapper;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Account;
using Cf.Libs.DataAccess.Repository.UserProfiles;
using Cf.Libs.Service.Dtos.Accounts;
using Cf.Libs.Service.Email;
using Microsoft.AspNetCore.Identity;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Cf.Libs.Service.Profile
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEmailSenderService _emailSender;
        private readonly IUserProfileRepository _userProfileRepository;

        public AccountService(
            IUnitOfWork unitOfWork, IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            EmailSenderService emailSender,
            IUserProfileRepository userProfileRepository) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<bool> SigninAsyn(SigninDto model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return true;
            }

            if (result.IsLockedOut)
            {
                return false;
            }

            return false;
        }

        public async Task<bool> SignupAsyn(SignupDto model)
        {
            User user = _mapper.Map<User>(model);
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                string callbackUrl = "";
                await _emailSender.SendEmailAsync(user.Email, "Confirm your email", $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                return true;
            }

            return false;
        }
    }
}