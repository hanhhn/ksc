using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Core.Request
{
    public class RequestContext : IRequestContext
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}