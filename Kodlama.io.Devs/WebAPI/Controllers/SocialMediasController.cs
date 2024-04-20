using Core.Application.Requests;
using Kodlama.io.Application.Features.SocialMedias.Commands.Create;
using Kodlama.io.Application.Features.SocialMedias.Queries.GetList;
using Kodlama.io.Application.Features.Users.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : BaseController
    {
        [HttpPost("/add")]
        public async Task<IActionResult> Create([FromBody] CreateSocialMediaCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("/list")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListSocialMediaQuery { PageRequest = pageRequest });
            return Ok(response);
        }
    }
}
