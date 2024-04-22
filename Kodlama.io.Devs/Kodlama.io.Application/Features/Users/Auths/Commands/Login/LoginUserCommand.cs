using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Application.Features.Users.Authentications.Rules;
using Kodlama.io.Application.Features.Users.Auths.Dtos;
using Kodlama.io.Application.Features.Users.EntityBaseDependency;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Application.Features.Users.Authentications.Commands.Login
{
    public  class LoginUserCommand: IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }


        public class LoginUserCommandHandler :
            UserDependResolver, IRequestHandler<LoginUserCommand, LoginDto>
        {
            readonly private ITokenHelper _tokenHelper;
            readonly private AuthBusinessRoles _authBusinessRoles;

            public LoginUserCommandHandler(IUserRepository userRepository,
                IMapper mapper,
                UserBusinessRules roles,
                ITokenHelper tokenHelper,
                 AuthBusinessRoles authBusinessRoles) : base(userRepository, mapper, roles)
            {
                _tokenHelper = tokenHelper;
                _authBusinessRoles = authBusinessRoles;
            }

            public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User user = await Rules.UserExistsWhenRequested(request.UserForLoginDto.Email);
                _authBusinessRoles.PasswordVerifyWhenLogin(user, request.UserForLoginDto.Password);
                AccessToken accessToken = _tokenHelper.CreateToken(user, new List<OperationClaim>());
                return new() { AccessToken = accessToken};
            }
        }
    }
}
