using Application.CQRS.Writerss.Dto;
using AutoMapper;
using Domain.Common;
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
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;
            public WriterUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }
            public async Task<Writers> Handle(WriterUpdateCommand request, CancellationToken cancellationToken)
            {
                var Model = mapper.Map<Writers>(request.Dto);
                var Result = unitOfWork.GetWriterService().UpdateWriters(Model);
                unitOfWork.Commit();
                return await Task.FromResult(Result);
            }
        }
    }
}
