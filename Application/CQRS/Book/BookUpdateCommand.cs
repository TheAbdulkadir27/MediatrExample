using Application.CQRS.Book.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Book
{
    public class BookUpdateCommand : IRequest<Books>
    {
        public BookDto BookDto { get; set; }
        public class BookUpdateCommandHandler : IRequestHandler<BookUpdateCommand, Books>
        {
            private readonly IMapper mapper;
            private readonly IBookService bookService;
            public BookUpdateCommandHandler(IMapper mapper, IBookService bookService)
            {
                this.mapper = mapper;
                this.bookService = bookService;
            }
            public Task<Books> Handle(BookUpdateCommand request, CancellationToken cancellationToken)
            {
                var books = mapper.Map<Books>(request.BookDto);
                return Task.FromResult(bookService.BookUpdate(bookService.BookGetById(request.BookDto.Id)));
            }
        }
    }
}
