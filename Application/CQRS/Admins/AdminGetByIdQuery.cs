using Domain.Common;
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
            private readonly IUnitOfWork UnitOfWork;
            public AdminGetByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                UnitOfWork = unitOfWork;
            }
            public Task<Admin> Handle(AdminGetByIdQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(UnitOfWork.GetAdminService().GetById(request.İd));
            }
        }
    }
}
