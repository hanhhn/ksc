using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cf.Libs.Core.Infrastructure.Paging
{
    public static class PagedListExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> value, int pageIndex, int pageSize)
        {
            return new PagedList<T>(value, pageIndex, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> value, int pageIndex, int pageSize)
        {
            return new PagedList<T>(value, pageIndex, pageSize);
        }
    }
}
