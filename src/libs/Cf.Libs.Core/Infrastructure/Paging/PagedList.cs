using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.Core.Infrastructure.Paging
{
    public class PagedList<T> : IPagedList<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalRecord { get; private set; }
        public int TotalPage { get; private set; }
        public IEnumerable<T> DataSource { get; private set; }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalRecord = source.Count();
            TotalPage = TotalRecord / pageSize;

            if (TotalRecord % pageSize > 0)
                TotalPage++;

            DataSource = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalRecord = source.Count();
            TotalPage = TotalRecord / pageSize;

            if (TotalRecord % pageSize > 0)
                TotalPage++;

            DataSource = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
