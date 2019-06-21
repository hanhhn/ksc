using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.Paging
{
    public class PagedList<T> : List<T>, IPagedList<T> where T : class, new()
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage { get; set; }
        public IEnumerable<T> DataSource { get; set; } = new List<T>();

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalRecord = source.Count();
            TotalPage = TotalRecord / pageSize;

            if (TotalRecord % pageSize > 0)
                TotalPage++;
         
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }
    }
}
