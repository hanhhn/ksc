using System;

namespace Cf.Libs.Core.Exeptions
{
    public class DataValidationException : Exception
    {
        public DataValidationException(string msg) : base(msg)
        {
        }
    }
}