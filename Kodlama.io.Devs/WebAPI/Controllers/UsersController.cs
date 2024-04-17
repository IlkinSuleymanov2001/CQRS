using Core.Application.Requests;
using Core.Security.Dtos;
using Kodlama.io.Application.Features.Users.Authentications.Commands.Login;
using Kodlama.io.Application.Features.Users.Auths.Commands.Register;
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

        [HttpGet("get{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetByIdUserQuery { Id = id });
            return Ok(response);
        }
        [HttpPatch("get/email")]
        public async Task<IActionResult> GetByEmail([FromBody]GetByEmailUserQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListUserQuery { PageRequest= pageRequest} );
            return Ok(response);
        }
    }
}
