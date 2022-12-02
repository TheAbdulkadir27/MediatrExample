using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Book
{
    public class BookDeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public class BookDeleteCommandHandler : IRequestHandler<BookDeleteCommand, bool>
        {
            private readonly IBookService bookService;
            public BookDeleteCommandHandler(IBookService bookService) => this.bookService = bookService;
            public Task<bool> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
            {
                return Task.FromResult(bookService.BookDelete(request.Id));
            }
        }
    }
}
