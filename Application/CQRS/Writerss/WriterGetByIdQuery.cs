using Domain.Common;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Writerss
{
    public class WriterGetByIdQuery : IRequest<Writers>
    {
        public Guid İd { get; set; }
        public class WriterGetByIdQueryHandler : IRequestHandler<WriterGetByIdQuery, Writers>
        {
            private readonly IUnitOfWork unitOfWork;

            public WriterGetByIdQueryHandler(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

            public async Task<Writers> Handle(WriterGetByIdQuery request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(unitOfWork.GetWriterService().GetById(request.İd));
            }
        }
    }
}
