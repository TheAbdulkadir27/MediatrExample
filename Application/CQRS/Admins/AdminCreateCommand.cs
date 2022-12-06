using AdminKayıt;
using Application.CQRS.Admins.Dto;
using AutoMapper;
using Domain.Common;
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
            private readonly IUnitOfWork unitOfWork;
            private readonly ICryPts Bcrypt;
            private readonly IMapper mapper;

            public AdminCreateCommanHandler(IUnitOfWork unitOfWork, ICryPts bcrypt, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                Bcrypt = bcrypt;
                this.mapper = mapper;
            }

            public async Task<Admin> Handle(AdminCreateCommand request, CancellationToken cancellationToken)
            {
                var pass = Bcrypt.Hasher(request.Admins.Password);
                var model = mapper.Map<Admin>(request.Admins);
                model.Password = pass;
                unitOfWork.GetAdminService().AdminAdd(model);
                unitOfWork.Commit();
                return await Task.FromResult(model);
            }
        }
    }
}
