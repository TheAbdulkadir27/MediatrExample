using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class BookAuthors
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Books))]
        public Guid BookId { get; set; }
        public Books Books { get; set; }

        [ForeignKey(nameof(Writers))]
        public Guid WriterId { get; set; }
        public Writers Writers { get; set; }
    }
}
