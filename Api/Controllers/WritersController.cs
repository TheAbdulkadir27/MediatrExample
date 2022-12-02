using Application.CQRS.Writerss;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IMediator mediator;
        public WritersController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{id}")]
        public async Task<Writers> GetById(Guid id)
        {
            var query = new WriterGetByIdQuery() { İd = id };
            return await mediator.Send(query);
        }
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var query = new WriterDeleteCommand() { Id = id };
            return await mediator.Send(query);
        }
        [HttpPost]
        public async Task<Writers> WritesCreate(WriterCreateCommand writerCreate)
        {
            return await mediator.Send(writerCreate);
        }
        [HttpPut]
        public async Task<Writers> WritersUpdate(WriterUpdateCommand writerUpdate)
        {
            return await mediator.Send(writerUpdate);
        }
    }
}
