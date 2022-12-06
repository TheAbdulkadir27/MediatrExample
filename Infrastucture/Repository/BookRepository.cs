using Domain.Common;
using Domain.Entity;
using Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastucture.Repository
{
    public class BookRepository : IBookService
    {
        private readonly DataContext dataContext;
        public BookRepository(DataContext DataContext)
        {
            this.dataContext = DataContext;
        }
        public Books BookAdd(Books books)
        {
            dataContext.Set<Books>().Add(books);
            return books;
        }
        public bool BookDelete(Guid id)
        {
            dataContext.Books.Remove(BookGetById(id));
            return true;
        }

        public Books BookUpdate(Books book)
        {
            dataContext.Set<Books>().Update(book);
            return book;
        }
        public Books BookGetById(Guid id)
        {
            return dataContext.Books.FirstOrDefault(v => v.Id == id);
        }
        public List<Books> PageMaxAndMin(Specification<Books> specification)
        {
            return dataContext.Books.Where(specification.Expression()).ToList();
        }
    }
}
