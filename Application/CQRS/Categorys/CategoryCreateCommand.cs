using Application.CQRS.Categorys.Dto;
using AutoMapper;
using Domain.Common;
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
            private readonly IUnitOfWork unitOfWork;
            public CategoryCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                this.mapper = mapper;
                this.unitOfWork = unitOfWork;
            }
            public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
            {
                if (request.Dto.Id == Guid.Empty)
                    request.Dto.Id = Guid.NewGuid();
                var s = mapper.Map<Category>(request.Dto);
                var sa = unitOfWork.GetCategoryService().Add(s);
                unitOfWork.Commit();
                return await Task.FromResult(sa);
            }
        }
    }
}
