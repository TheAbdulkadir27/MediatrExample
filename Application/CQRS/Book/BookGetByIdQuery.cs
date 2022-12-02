using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Book
{
    public class BookGetByIdQuery : IRequest<Books>
    {
        public Guid Id { get; set; }
        public class BookGetByIdQueryHandler : IRequestHandler<BookGetByIdQuery, Books>
        {
            private readonly IBookService bookService;
            public BookGetByIdQueryHandler(IBookService bookService)
            {
                this.bookService = bookService;
            }
            public Task<Books> Handle(BookGetByIdQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(bookService.BookGetById(request.Id));
            }
        }
    }
}
