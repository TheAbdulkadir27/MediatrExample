using Application.CQRS.Writerss.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Writerss
{
    public class WriterCreateCommand : IRequest<Writers>
    {
        public WritersDto Dto { get; set; }
        public class WriterCreateCommandHandler : IRequestHandler<WriterCreateCommand, Writers>
        {
            private readonly IWritersService writersService;
            private readonly IMapper mapper;
            public WriterCreateCommandHandler(IWritersService writersService, IMapper mapper)
            {
                this.writersService = writersService;
                this.mapper = mapper;
            }
            public async Task<Writers> Handle(WriterCreateCommand request, CancellationToken cancellationToken)
            {
                request.Dto.Id = Guid.NewGuid();
                var s = mapper.Map<Writers>(request.Dto);
                return await Task.FromResult(writersService.AddWriters(s));
            }
        }
    }
}
