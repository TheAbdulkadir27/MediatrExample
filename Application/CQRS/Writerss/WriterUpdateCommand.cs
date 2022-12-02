using Application.CQRS.Writerss.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Writerss
{
    public class WriterUpdateCommand : IRequest<Writers>
    {
        public WritersDto Dto { get; set; }

        public class WriterUpdateCommandHandler : IRequestHandler<WriterUpdateCommand, Writers>
        {
            private readonly IMapper mapper;
            private readonly IWritersService writersService;
            public WriterUpdateCommandHandler(IMapper mapper, IWritersService writersService)
            {
                this.mapper = mapper;
                this.writersService = writersService;
            }
            public async Task<Writers> Handle(WriterUpdateCommand request, CancellationToken cancellationToken)
            {
                var s = mapper.Map<Writers>(request.Dto);
                return await Task.FromResult(writersService.UpdateWriters(s));
            }
        }
    }
}
