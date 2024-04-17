using Kodlama.io.Application.Features.UserSocialMedias.Commands.Create;
using Kodlama.io.Application.Features.UserSocialMedias.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialMediasController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Add(CreateUserSocialMediaCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Register([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetByIdSocialMediaQuery { Id= id});
            return Ok(response);
        }
    }
}
