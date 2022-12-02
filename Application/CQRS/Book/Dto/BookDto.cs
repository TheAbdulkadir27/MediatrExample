using Domain.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.CQRS.Book.Dto
{
    public class BookDto
    {
        public BookDto()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public Guid CategoryId { get; set; }
        public int Page { get; set; }
        public IEnumerable<BookAuthorDto> BooksAuthors { get; set; }
    }
}