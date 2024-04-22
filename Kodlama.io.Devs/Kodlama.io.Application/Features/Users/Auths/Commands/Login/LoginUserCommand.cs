using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Application.Features.Users.Authentications.Rules;
using Kodlama.io.Application.Features.Users.Auths.Dtos;
using Kodlama.io.Application.Features.Users.EntityBaseDependency;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Services.AuthService;
using Kodlama.io.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Application.Features.Users.Authentications.Commands.Login
{
    public  class LoginUserCommand: IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string  IpAddress { get; set; }


        public class LoginUserCommandHandler :
            UserDependResolver, IRequestHandler<LoginUserCommand, LoginDto>
        {
            readonly private AuthBusinessRoles _authBusinessRoles;
            readonly private IAuthService _authService;

            public LoginUserCommandHandler(IUserRepository userRepository,
                IMapper mapper,
                UserBusinessRules roles,
                IAuthService authService,
                 AuthBusinessRoles authBusinessRoles) : base(userRepository, mapper, roles)
            {
                _authBusinessRoles = authBusinessRoles;
                _authService = authService;
            }

            public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User user = await Rules.UserExistsWhenRequested(request.UserForLoginDto.Email);
                _authBusinessRoles.PasswordVerifyWhenLogin(user, request.UserForLoginDto.Password);

                AccessToken accessToken =await  _authService.CreateAccessToken(user);
                await _authService.RemoveRefreshToken(user);

                RefreshToken newRefresfToken = await _authService.CreateRefreshToken(user,request.IpAddress);
                await _authService.AddRefreshToken(newRefresfToken);
                return new LoginDto
                {
                    AccessToken = accessToken,
                    RefreshToken = newRefresfToken
                };
            }
        }
    }
}
