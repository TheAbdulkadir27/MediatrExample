using Domain.Common;
using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Categorys
{
    public class CategoryGetByIdQuery : IRequest<Category>
    {
        public Guid Id { get; set; }
        public class CategoryGetByIdQueryHandler : IRequestHandler<CategoryGetByIdQuery, Category>
        {
            private readonly IUnitOfWork unitOfWork;
            public CategoryGetByIdQueryHandler(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;
            public async Task<Category> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(unitOfWork.GetCategoryService().GetById(request.Id));
            }
        }
    }
}
