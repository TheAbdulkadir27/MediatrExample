using Domain.Common;
using Domain.Entity;
using MediatR;
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
            private readonly IUnitOfWork unitOfWork;
            public AdminSearchQueryHandler(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;
            public async Task<Admin[]> Handle(AdminSearchQuery request, CancellationToken cancellationToken)
            {
                var filter = request.Admin;
                var page = request.Page;
                var spec = new AdminSpecification(filter);
                Admin[] admins = unitOfWork.GetAdminService().Search(spec, page);
                return await Task.FromResult(admins);
            }
        }
    }
}
