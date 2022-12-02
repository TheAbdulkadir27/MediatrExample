﻿using Domain.Entity;
using Infrastucture.Context;
using System;
using System.Linq;

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
            dataContext.SaveChanges();
            return books;
        }
        public bool BookDelete(Guid id)
        {
            dataContext.Books.Remove(BookGetById(id));
            if (dataContext.SaveChanges() > 0)
                return true;
            return false;
        }

        public Books BookUpdate(Books book)
        {
            dataContext.Set<Books>().Update(book);
            dataContext.SaveChanges();
            return book;
        }
        public Books BookGetById(Guid id)
        {
            return dataContext.Books.FirstOrDefault(v => v.Id == id);
        }
    }
}