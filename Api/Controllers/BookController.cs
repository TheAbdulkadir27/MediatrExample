using Application.CQRS.Book;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;
        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<Books> GetById(Guid id)
        {
            var query = new BookGetByIdQuery() { Id = id };
            return await mediator.Send(query);
        }
        [HttpPost]
        public async Task<Books> CreateBook(BookCreateCommand bookCreate)
        {
            return await mediator.Send(bookCreate);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteBook(Guid id)
        {
            var query = new BookDeleteCommand() { Id = id };
            return await mediator.Send(query);
        }
        [HttpPut]
        public async Task<Books> UpdateBook(BookUpdateCommand bookUpdate)
        {
            return await mediator.Send(bookUpdate);
        }


        [HttpPost]
        [Route("api/[controller]/MaxAndMinPage")]
        public async Task<Books[]> MaxAndMinPage(int max, int min)
        {
            return await mediator.Send(new BookMaxPageAndMinimumPage() { MaxPage = max, MinPage = min });
        }
    }
}
