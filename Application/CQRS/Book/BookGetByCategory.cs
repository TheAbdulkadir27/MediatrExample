using Domain.Common;
using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Book
{
    public class BookGetByCategory : IRequest<Books[]>
    {
        public Guid CategoryId { get; set; }
        public class BookGetByCategoryHandler : IRequestHandler<BookGetByCategory, Books[]>
        {
            private readonly IUnitOfWork unitOfWork;
            public BookGetByCategoryHandler(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;
            public async Task<Books[]> Handle(BookGetByCategory request, CancellationToken cancellationToken)
            {
                var Result = unitOfWork.GetBookService().PageMaxAndMin(new BookCategoryGetById() { CategoryId = request.CategoryId }).ToArray();
                return await Task.FromResult(Result);
            }
        }
    }
}
