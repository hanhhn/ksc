using System;

namespace Cf.Libs.Core.Exeptions
{
    public class InformationException : Exception
    {
        public InformationException(string msg) : base(msg)
        {
        }
    }
}