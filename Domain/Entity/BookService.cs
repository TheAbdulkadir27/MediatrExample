using System;

namespace Domain.Entity
{
    public interface IBookService
    {
        Books BookAdd(Books books);
        bool BookDelete(Guid id);
        Books BookUpdate(Books books);
        Books BookGetById(Guid id);
    }
}
