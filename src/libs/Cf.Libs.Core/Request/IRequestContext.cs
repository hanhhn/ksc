using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Request
{
    public interface IRequestContext
    {
        int UserId { get; set; }
        string UserName { get; set; }
    }
}
