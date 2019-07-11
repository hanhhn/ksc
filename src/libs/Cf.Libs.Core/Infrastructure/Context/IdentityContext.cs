using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.Context
{
    public class IdentityContext : IIdentityContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityContext(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}