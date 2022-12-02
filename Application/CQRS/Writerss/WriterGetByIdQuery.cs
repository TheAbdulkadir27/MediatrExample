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
            private readonly IWritersService writersService;
            public WriterGetByIdQueryHandler(IWritersService writersService) => this.writersService = writersService;
            public async Task<Writers> Handle(WriterGetByIdQuery request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(writersService.GetById(request.İd));
            }
        }
    }
}
