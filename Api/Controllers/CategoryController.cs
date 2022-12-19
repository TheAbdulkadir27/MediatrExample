using Application.CQRS.Categorys;
using Domain.Common;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<Category> GetById(Guid id)
        {
            return await mediator.Send(new CategoryGetByIdQuery() { Id = id });
        }
        [HttpPost]
        public async Task<Category> CreateCategory(CategoryCreateCommand categoryCreate)
        {
            return await mediator.Send(categoryCreate);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCategory(Guid id)
        {
            return await mediator.Send(new CategoryDeleteCommand() { Id = id });
        }
        [HttpPut]
        public async Task<Category> UpdateCategory(CategoryUpdateCommand categoryUpdate)
        {
            return await mediator.Send(categoryUpdate);
        }
    }
}
