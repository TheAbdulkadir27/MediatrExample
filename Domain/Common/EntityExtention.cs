using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Common
{
    public static class EntityExtention
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> queryable, Specification<T> filters = null)
        {
            return filters is null ? queryable : queryable.Where(filters!.Expression());
        }
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, Pagition pagination = null)
        {
            if (pagination is null)
            {
                return queryable.Take(10);
            }
            var (skip, rows) = ((pagination.Page - 1) * pagination.Rows, pagination.Rows);
            return queryable.Skip(skip).Take(rows);
        }
    }
}
