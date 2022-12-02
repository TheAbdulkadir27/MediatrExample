using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Admins
{
    public class AdminDeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public class AdminDeleteCommandHandler : IRequestHandler<AdminDeleteCommand, bool>
        {
            private readonly IAdminService adminService;
            public AdminDeleteCommandHandler(IAdminService adminService)
            {
                this.adminService = adminService;
            }
            public Task<bool> Handle(AdminDeleteCommand request, CancellationToken cancellationToken)
            {
                return Task.FromResult(adminService.AdminDelete(request.Id));
            }
        }
    }
}
