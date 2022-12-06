using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public interface IBookService
    {
        Books BookAdd(Books books);
        bool BookDelete(Guid id);
        Books BookUpdate(Books books);
        Books BookGetById(Guid id);
        List<Books> PageMaxAndMin(Specification<Books> specification);
    }
}
