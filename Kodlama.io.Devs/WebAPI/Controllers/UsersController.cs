using Core.Application.Requests;
using Core.Security.Dtos;
using Kodlama.io.Application.Features.Users.Authentications.Commands.Login;
using Kodlama.io.Application.Features.Users.Auths.Commands.Register;
using Kodlama.io.Application.Features.Users.Commands.Create;
using Kodlama.io.Application.Features.Users.Commands.Update;
using Kodlama.io.Application.Features.Users.Queries.Get.Email;
using Kodlama.io.Application.Features.Users.Queries.Get.GetById;
using Kodlama.io.Application.Features.Users.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetByIdUserQuery { Id = id });
            return Ok(response);
        }
        [HttpPatch("get/mail")]
        public async Task<IActionResult> GetByEmail([FromBody]GetByEmailUserQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListUserQuery { PageRequest= pageRequest} );
            return Ok(response);
        }

        [HttpPost("/create")]
        public async Task<IActionResult> Create([FromBody]  CreateUserCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("/upadte")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
