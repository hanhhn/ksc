using Cf.Libs.Core.Enums;
using System.Collections.Generic;

namespace Cf.Libs.Core.BaseObject
{
    public class Result<T>
        where T : class, new()
    {
        public StatusCode Code { get; set; } = StatusCode.OK;
        public IEnumerable<Messages> Messages { get; set; } = new List<Messages>();
        public T Data { get; set; } = new T();
    }
}