﻿using Cf.Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Core.DataAccess.Entities
{
    public class UserToken : IdentityUserToken<int>, IEntityRoot
    {
    }
}
