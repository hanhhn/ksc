using System;

namespace Cf.Libs.Core.Exeptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string msg) : base(msg)
        {
        }
    }
}