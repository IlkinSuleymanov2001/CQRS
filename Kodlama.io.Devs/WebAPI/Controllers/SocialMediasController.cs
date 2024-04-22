using Core.Application.Requests;
using Kodlama.io.Application.Features.SocialMedias.Commands.Create;
using Kodlama.io.Application.Features.SocialMedias.Commands.Delete.Id;
using Kodlama.io.Application.Features.SocialMedias.Commands.Delete.Name;
using Kodlama.io.Application.Features.SocialMedias.Commands.Update;
using Kodlama.io.Application.Features.SocialMedias.Queries.GetById;
using Kodlama.io.Application.Features.SocialMedias.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CreateSocialMediaCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetByIdSocialMediaQuery { Id = id });
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteByIdSocialMediaCommand { Id = id });
            return Ok(response);
        }

        [HttpDelete("delete/byname")]
        public async Task<IActionResult> Delete([FromBody] DeleteByNameSocialMediaCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListSocialMediaQuery { PageRequest = pageRequest });
            return Ok(response);
        }
    }
}
