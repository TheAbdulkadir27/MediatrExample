using AdminKayıt;
using Application.CQRS.Admins.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Admins
{
    public class AdminCreateCommand : IRequest<Admin>
    {
        public AdminDto Admins { get; set; }
        public class AdminCreateCommanHandler : IRequestHandler<AdminCreateCommand, Admin>
        {
            private readonly IAdminService adminService;
            private readonly ICryPts Bcrypt;
            private readonly IMapper mapper;
            public AdminCreateCommanHandler(IAdminService adminService, ICryPts _Bcrypt, IMapper mapper)
            {
                this.adminService = adminService;
                this.Bcrypt = _Bcrypt;
                this.mapper = mapper;
            }
            public async Task<Admin> Handle(AdminCreateCommand request, CancellationToken cancellationToken)
            {
                var pass = Bcrypt.Hasher(request.Admins.Password);
                var model = mapper.Map<Admin>(request.Admins);
                model.Password = pass;
                adminService.AdminAdd(model);
                return await Task.FromResult(model);
            }
        }
    }
}
