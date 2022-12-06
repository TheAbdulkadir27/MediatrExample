using Domain.Common;
using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Categorys
{
    public class CategoryDeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;

            public CategoryDeleteCommandHandler(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

            public async Task<bool> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
            {
                var Result = unitOfWork.GetCategoryService().Delete(request.Id);
                unitOfWork.Commit();
                return await Task.FromResult(Result);
            }
        }
    }
}
