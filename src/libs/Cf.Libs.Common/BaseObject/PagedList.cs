using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.Common.BaseObject
{
    public class PagedList<T> : List<T> where T : class, new()
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage { get; set; }
        public IEnumerable<T> DataSource { get; set; } = new List<T>();

        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            TotalRecord = source.Count;
            TotalPage = TotalRecord / pageSize;

            if (TotalRecord % pageSize > 0)
                TotalPage++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }
    }
}