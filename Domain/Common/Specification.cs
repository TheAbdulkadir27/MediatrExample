using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Common
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> Expression();
        public bool IsSatısFiedBy(T entity)
        {
            Func<T, bool> Predicate = Expression().Compile();
            return Predicate(entity);
        }
    }
}
