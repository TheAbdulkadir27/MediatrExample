using Domain.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.CQRS.Book.Dto
{
    public class BookAuthorDto
    {
        public Guid Id { get; set; }
        public Guid WriterId { get; set; }
    }
}
