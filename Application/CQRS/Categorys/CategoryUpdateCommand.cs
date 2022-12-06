using Application.CQRS.Categorys.Dto;
using AutoMapper;
using Domain.Common;
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
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;
            public CategoryUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }
            public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
            {
                var s = mapper.Map<Category>(request.categoryDto);
                var Result = unitOfWork.GetCategoryService().Update(unitOfWork.GetCategoryService().GetById(s.Id));
                unitOfWork.Commit();
                return await Task.FromResult(Result);
            }
        }
    }
}
