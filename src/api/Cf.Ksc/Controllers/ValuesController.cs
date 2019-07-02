using Cf.Libs.DataAccess.Entities.Account;
using Cf.Libs.Service.Profile;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cf.Ksc.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserProfileService _service;

        public ValuesController(IUserProfileService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("profiles")]
        public IEnumerable<UserProfile> UserProfiles()
        {
            return _service.UserProfiles();
        }

        [HttpGet]
        [Route("add")]
        public int Add()
        {
            return _service.Add();
        }
    }
}
