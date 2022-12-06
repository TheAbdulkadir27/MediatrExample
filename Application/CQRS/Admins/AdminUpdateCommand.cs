using AdminKayıt;
using Application.CQRS.Admins.Dto;
using AutoMapper;
using Domain.Common;
using Domain.Entity;
using Infrastucture.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Admins
{
    public class AdminUpdateCommand : IRequest<Admin>
    {
        public AdminDto Admin { get; set; }
        public class AdminUpdateCommandHandler : IRequestHandler<AdminUpdateCommand, Admin>
        {
            private readonly IMapper mapper;
            private readonly ICryPts ısha256;
            private readonly IUnitOfWork unitOfWork;
            public AdminUpdateCommandHandler(IMapper mapper, ICryPts ısha256, IUnitOfWork unitOfWork)
            {
                this.mapper = mapper;
                this.ısha256 = ısha256;
                this.unitOfWork = unitOfWork;
            }

            public async Task<Admin> Handle(AdminUpdateCommand request, CancellationToken cancellationToken)
            {
                Admin admin = mapper.Map<Admin>(request.Admin);
                admin.Password = ısha256.Hasher(admin.Password);
                var value = unitOfWork.GetAdminService().AdminUpdate(admin);
                unitOfWork.Commit();
                return await Task.FromResult(value);
            }
        }
    }
}
