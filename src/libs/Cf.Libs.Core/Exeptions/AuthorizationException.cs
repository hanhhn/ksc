using System;

namespace Cf.Libs.Core.Exeptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string msg) : base(msg)
        {
        }
    }
}