using Domain.Common;
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
            private readonly IUnitOfWork unitOfWork;
            public BookGetByIdQueryHandler(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;
            public Task<Books> Handle(BookGetByIdQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(unitOfWork.GetBookService().BookGetById(request.Id));
            }
        }
    }
}
