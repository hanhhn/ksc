using System;

namespace Cf.Libs.Core.Exeptions
{
    class PageNotFoundException : Exception
    {
        public PageNotFoundException(string msg) : base(msg)
        {
        }
    }
}