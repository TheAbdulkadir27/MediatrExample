using Domain.Common;
using Domain.Entity;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Admins
{
    public class AdminSearchQuery : IRequest<Admin[]>
    {
        public Admin Admin { get; set; }
        public Pagition Page { get; set; }
        public class AdminSearchQueryHandler : IRequestHandler<AdminSearchQuery, Admin[]>
        {
            private readonly IUnitOfWork UnitOfWork;
            private readonly IMemoryCache _MemoryCache;
            private const string Key = "AdminSearch";
            public AdminSearchQueryHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
            {
                this.UnitOfWork = unitOfWork;
                _MemoryCache = memoryCache;
            }
            public async Task<Admin[]> Handle(AdminSearchQuery request, CancellationToken cancellationToken)
            {
                var filter = request.Admin;
                var page = request.Page;
                var spec = new AdminSpecification(filter);
                Admin[] admins;
                if (!_MemoryCache.TryGetValue(Key, out admins))
                {
                    admins = UnitOfWork.GetAdminService().Search(spec, page);
                    var CacheExpOption = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                        Priority = CacheItemPriority.Low
                    };
                    _MemoryCache.Set(Key, admins, CacheExpOption);
                }
                return await Task.FromResult(admins);
            }
        }
    }
}
