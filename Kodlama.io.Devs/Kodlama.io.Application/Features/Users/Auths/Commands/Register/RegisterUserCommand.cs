using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Application.Features.Users.Auths.Dtos;
using Kodlama.io.Application.Features.Users.EntityBaseDependency;
using Kodlama.io.Application.Features.Users.Helpers;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Services.AuthService;
using Kodlama.io.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Application.Features.Users.Auths.Commands.Register
{
    public class RegisterUserCommand : IRequest<RegisterDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }


        public class RegisterUserCommandHandler :
            UserDependResolver,
            IRequestHandler<RegisterUserCommand, RegisterDto>
        {
            readonly private IAuthService _authService;

            public RegisterUserCommandHandler(IUserRepository userRepository,
                IMapper mapper,
                UserBusinessRules roles,
                IAuthService authService) : base(userRepository, mapper, roles)
            {
                _authService = authService;
            }

            public async Task<RegisterDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await Rules.UserEmailCanNotBeDublicatedWhenRequested(request.UserForRegisterDto.Email);

                User user = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Status = true
                };

                user.SetUserPasswordDatas(request.UserForRegisterDto.Password);

                User addedUser = await UserRepository.AddAsync(user);
                AccessToken accesToken =await  _authService.CreateAccessToken(addedUser);
                var refreshToken = await _authService.CreateRefreshToken(addedUser, request.IpAddress);
                RefreshToken addedRefreshToken  = await _authService.AddRefreshToken(refreshToken);
                return new()
                { 
                   AccessToken = accesToken,
                   RefreshToken = addedRefreshToken
                };
                
            }
        }

    }
}
