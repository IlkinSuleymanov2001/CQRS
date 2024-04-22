using Core.Security.Dtos;
using Kodlama.io.Application.Features.Users.Authentications.Commands.Login;
using Kodlama.io.Application.Features.Users.Auths.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControlers : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var response = await Mediator.Send(new LoginUserCommand { UserForLoginDto = userForLogin});
            return Ok(response?.AccessToken);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto  userForRegisterDto)
        {
            var response = await Mediator.Send(new RegisterUserCommand { UserForRegisterDto   = userForRegisterDto});
            return Ok(response?.AccessToken);
        }
    }
}
