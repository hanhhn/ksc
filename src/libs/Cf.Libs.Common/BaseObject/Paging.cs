using System.Collections.Generic;

namespace Cf.Libs.Common.BaseObject
{
    public class Paging<T> where T : class, new()
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public IEnumerable<T> DataSource { get; set; } = new List<T>();
    }
}