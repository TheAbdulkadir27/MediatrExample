using Application.CQRS.Categorys.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Categorys
{
    public class CategoryUpdateCommand : IRequest<Category>
    {
        public CategoryDto categoryDto { get; set; }

        public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
        {
            private readonly ICategoryService _categoryService;
            private readonly IMapper mapper;
            public CategoryUpdateCommandHandler(ICategoryService categoryService, IMapper Mapper)
            {
                _categoryService = categoryService;
                this.mapper = Mapper;
            }
            public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
            {
                var s = mapper.Map<Category>(request.categoryDto);
                return await Task.FromResult(_categoryService.Update(s));
            }
        }
    }
}
