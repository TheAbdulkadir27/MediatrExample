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
            private readonly IUnitOfWork unitOfWork;
            public BookPage400_Or_Higher(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;
            public async Task<Books[]> Handle(BookMaxPageAndMinimumPage request, CancellationToken cancellationToken)
            {
                var value = unitOfWork.GetBookService().PageMaxAndMin(new MaxPageAndMinumumPage(request.MaxPage, request.MinPage));
                return await Task.FromResult(value.ToArray());
            }
        }
    }
}
