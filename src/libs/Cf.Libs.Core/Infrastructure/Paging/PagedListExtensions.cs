using System;
using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.Core.Infrastructure.Paging
{
    public static class PagedListExtensions
    {
        private static bool IsValid(int pageIndex, int pageSize)
        {
            return pageIndex >= 0 && pageSize >= 1;
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> value, int pageIndex, int pageSize)
        {
            if (!IsValid(pageIndex, pageSize))
                throw new ArgumentException(string.Format("Something wrong with pageIndex: {0} or pageSize: {1}", pageIndex, pageSize));

            return new PagedList<T>(value, pageIndex, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> value, int pageIndex, int pageSize)
        {
            if (!IsValid(pageIndex, pageSize))
                throw new ArgumentException(string.Format("Something wrong with pageIndex: {0} or pageSize: {1}", pageIndex, pageSize));

            return new PagedList<T>(value, pageIndex, pageSize);
        }
    }
}
