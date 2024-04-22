using Kodlama.io.Application.Features.UserSocialMedias.Commands.Create;
using Kodlama.io.Application.Features.UserSocialMedias.Commands.Delete;
using Kodlama.io.Application.Features.UserSocialMedias.Queries.GetById;
using Kodlama.io.Application.Features.UserSocialMedias.Queries.GetList.UserId;
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteUserSocialMediaCommand { Id = id});
            return Ok(response);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetByIdSocialMediaQuery { Id= id});
            return Ok(response);
        }

        [HttpGet("list/byuserid/{userId}")]
        public async Task<IActionResult> GetListByUserId([FromRoute] int userId)
        {
            var response = await Mediator.Send(new GetListByUserIdUserSocialMediaQuery { UserId = userId });
            return Ok(response);
        }
    }
}
