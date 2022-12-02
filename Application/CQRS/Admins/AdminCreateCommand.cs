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
            private readonly Isha256 ısha256;
            private readonly IMapper mapper;
            public AdminCreateCommanHandler(IAdminService adminService, Isha256 ısha256, IMapper mapper)
            {
                this.adminService = adminService;
                this.ısha256 = ısha256;
                this.mapper = mapper;
            }
            public async Task<Admin> Handle(AdminCreateCommand request, CancellationToken cancellationToken)
            {
                var pass = ısha256.ComputeSha256Hash(request.Admins.Password);
                var model = mapper.Map<Admin>(request.Admins);
                model.Password = pass;
                adminService.AdminAdd(model);
                return await Task.FromResult(model);
            }
        }
    }
}
