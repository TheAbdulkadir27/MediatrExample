using Application.CQRS.Admins;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;
        public AdminController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<Admin> GetById(Guid id)
        {
            return await mediator.Send(new AdminGetByIdQuery() { İd = id });
        }
        [HttpPost]
        public async Task<Admin> CreateAdmin(AdminCreateCommand adminCreate)
        {
            return await mediator.Send(adminCreate);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAdmin(Guid id)
        {
            return await mediator.Send(new AdminDeleteCommand() { Id = id });
        }

        [HttpPut]
        public async Task<Admin> UpdateAdmin(AdminUpdateCommand admin)
        {
            return await mediator.Send(admin);
        }
    }
}
