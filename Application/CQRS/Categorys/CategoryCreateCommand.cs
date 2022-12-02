using Application.CQRS.Categorys.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Categorys
{
    public class CategoryCreateCommand : IRequest<Category>
    {
        public CategoryDto Dto { get; set; }
        public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
        {
            private readonly IMapper mapper;
            private readonly ICategoryService categoryService;
            public CategoryCreateCommandHandler(IMapper mapper, ICategoryService categoryService)
            {
                this.mapper = mapper;
                this.categoryService = categoryService;
            }
            public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
            {
                if (request.Dto.Id == Guid.Empty)
                    request.Dto.Id = Guid.NewGuid();
                var s = mapper.Map<Category>(request.Dto);
                return await Task.FromResult(categoryService.Add(s));
            }
        }
    }
}
