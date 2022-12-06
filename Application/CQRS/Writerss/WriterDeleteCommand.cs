using Domain.Common;
using Domain.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Application.CQRS.Writerss
{
    public class WriterDeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public class WriterDeleteCommandHandler : IRequestHandler<WriterDeleteCommand, bool>
        {
            private readonly IUnitOfWork _UnitOfWork;
            public WriterDeleteCommandHandler(IUnitOfWork unitOfWork) => _UnitOfWork = unitOfWork;
            public async Task<bool> Handle(WriterDeleteCommand request, CancellationToken cancellationToken)
            {
                var value = _UnitOfWork.GetWriterService().DeleteWriters(request.Id);
                _UnitOfWork.Commit();
                return await Task.FromResult(value);
            }
        }
    }
}
