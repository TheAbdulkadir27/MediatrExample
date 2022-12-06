using Domain.Common;
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
            private readonly IUnitOfWork unitOfWork;
            public BookDeleteCommandHandler(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;
            public Task<bool> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
            {
                var Result = unitOfWork.GetBookService().BookDelete(request.Id);
                unitOfWork.Commit();
                return Task.FromResult(Result);
            }
        }
    }
}
