using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class Books
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public int Page { get; set; }
        public IEnumerable<BookAuthors> BooksAuthors { get; set; }
    }
}
