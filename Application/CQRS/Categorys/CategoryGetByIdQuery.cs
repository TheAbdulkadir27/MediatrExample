using Domain.Common;
using Domain.Entity;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Runtime.CompilerServices;
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
            private readonly IMemoryCache memoryCache;
            private const string Key = "CategoryGetById";
            public CategoryGetByIdQueryHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
            {
                this.unitOfWork = unitOfWork;
                this.memoryCache = memoryCache;
            }
            public async Task<Category> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
            {
                Category catalog;
                if (!memoryCache.TryGetValue(Key, out catalog))
                {
                    catalog = unitOfWork.GetCategoryService().GetById(request.Id);
                    var CacheExpOption = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(10),
                        Priority = CacheItemPriority.Normal
                    };
                    memoryCache.Set(Key, catalog, CacheExpOption);
                }
                return await Task.FromResult(catalog);
            }
        }
    }
}
