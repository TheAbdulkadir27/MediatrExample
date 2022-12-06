using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Common
{
    public class BookCategoryGetById : Specification<Books>
    {
        public Guid CategoryId { get; set; }
        public override Expression<Func<Books, bool>> Expression()
        {
            return r => r.Category.Id == CategoryId;
        }
    }
}
