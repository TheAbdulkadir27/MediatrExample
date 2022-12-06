using Application.CQRS.Writerss.Dto;
using AutoMapper;
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
    public class WriterCreateCommand : IRequest<Writers>
    {
        public WritersDto Dto { get; set; }
        public class WriterCreateCommandHandler : IRequestHandler<WriterCreateCommand, Writers>
        {
            private readonly IUnitOfWork _UnitOfWORK;
            private readonly IMapper mapper;
            public WriterCreateCommandHandler(IUnitOfWork writersService, IMapper mapper)
            {
                this._UnitOfWORK = writersService;
                this.mapper = mapper;
            }
            public async Task<Writers> Handle(WriterCreateCommand request, CancellationToken cancellationToken)
            {
                request.Dto.Id = Guid.NewGuid();
                var s = mapper.Map<Writers>(request.Dto);
                var value = _UnitOfWORK.GetWriterService().AddWriters(s);
                _UnitOfWORK.Commit();
                return await Task.FromResult(value);
            }
        }
    }
}
