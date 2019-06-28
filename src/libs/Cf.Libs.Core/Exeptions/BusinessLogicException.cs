using System;

namespace Cf.Libs.Core.Exeptions
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string msg) : base(msg)
        {

        }
    }
}