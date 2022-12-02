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
            private readonly ICategoryService CategoryService;
            public CategoryDeleteCommandHandler(ICategoryService categoryService)
            {
                CategoryService = categoryService;
            }
            public async Task<bool> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(CategoryService.Delete(request.Id));
            }
        }
    }
}
