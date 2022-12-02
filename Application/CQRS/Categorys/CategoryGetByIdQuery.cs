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
            private readonly ICategoryService categoryService;
            public CategoryGetByIdQueryHandler(ICategoryService categoryService) => this.categoryService = categoryService;
            public async Task<Category> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(categoryService.GetById(request.Id));
            }
        }
    }
}
