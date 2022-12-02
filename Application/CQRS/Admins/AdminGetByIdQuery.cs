using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Admins
{
    public class AdminGetByIdQuery : IRequest<Admin>
    {
        public Guid İd { get; set; }
        public class AdminGetByIdQueryHandler : IRequestHandler<AdminGetByIdQuery, Admin>
        {
            private readonly IAdminService adminService;
            public AdminGetByIdQueryHandler(IAdminService adminService) => this.adminService = adminService;
            public Task<Admin> Handle(AdminGetByIdQuery request, CancellationToken cancellationToken) => Task.FromResult(adminService.GetById(request.İd));
        }
    }
}
