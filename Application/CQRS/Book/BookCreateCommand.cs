using Application.CQRS.Book.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Book
{
    public class BookCreateCommand : IRequest<Books>
    {
        public BookDto Books { get; set; }
        public class BookCreateCommandHandler : IRequestHandler<BookCreateCommand, Books>
        {
            private readonly IBookService bookService;
            private readonly IMapper mapper;
            public BookCreateCommandHandler(IBookService bookService, IMapper mapper)
            {
                this.bookService = bookService;
                this.mapper = mapper;
            }
            public async Task<Books> Handle(BookCreateCommand request, CancellationToken cancellationToken)
            {
                var books = mapper.Map<Books>(request.Books);
                return await Task.FromResult(bookService.BookAdd(books));
            }
        }
    }
}
