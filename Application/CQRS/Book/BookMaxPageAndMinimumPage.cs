using Domain.Common;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Book
{
    public class BookMaxPageAndMinimumPage : IRequest<Books[]>
    {
        public int MaxPage { get; set; }
        public int MinPage { get; set; }
        public class BookPage400_Or_Higher : IRequestHandler<BookMaxPageAndMinimumPage, Books[]>
        {
            private readonly IBookService _bookService;
            public BookPage400_Or_Higher(IBookService bookService) => _bookService = bookService;
            public async Task<Books[]> Handle(BookMaxPageAndMinimumPage request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(_bookService.PageMaxAndMin(new MaxPageAndMinumumPage(request.MaxPage, request.MinPage)).ToArray());
            }
        }
    }
}
