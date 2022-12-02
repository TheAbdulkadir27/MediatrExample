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
            private readonly IWritersService writersService;
            public WriterDeleteCommandHandler(IWritersService writersService)
            {
                this.writersService = writersService;
            }
            public async Task<bool> Handle(WriterDeleteCommand request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(writersService.DeleteWriters(request.Id));
            }
        }
    }
}
