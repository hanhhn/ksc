using Cf.Libs.Core.Enums;

namespace Cf.Libs.Core.BaseObject
{
    public class Messages
    {
        public string Code { get; set; }
        public MsgType Type { get; set; }
        public string Content { get; set; }
    }
}