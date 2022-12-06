using Domain.Common;
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
            private readonly IUnitOfWork unitOfWork;
            public AdminDeleteCommandHandler(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

            public Task<bool> Handle(AdminDeleteCommand request, CancellationToken cancellationToken)
            {
                var value = Task.FromResult(unitOfWork.GetAdminService().AdminDelete(request.Id));
                unitOfWork.Commit();
                return value;
            }
        }
    }
}
