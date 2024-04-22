using Core.Security.Dtos;
using Core.Security.Entities;
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
            var response = await Mediator.Send(new LoginUserCommand { 
                UserForLoginDto = userForLogin,
                IpAddress = GetIpAddress()
            });
            SetRefreshTokenToCookie(response.RefreshToken);
            return Ok(response?.AccessToken);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto  userForRegisterDto)
        {
            var response = await Mediator.Send(new RegisterUserCommand { 
                UserForRegisterDto= userForRegisterDto,
                IpAddress = GetIpAddress()
            });

            SetRefreshTokenToCookie(response.RefreshToken);
            return Ok(response?.AccessToken);
        }


        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
