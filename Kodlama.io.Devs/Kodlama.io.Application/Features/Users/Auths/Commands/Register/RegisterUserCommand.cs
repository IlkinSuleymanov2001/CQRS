using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Application.Features.Users.Auths.Models;
using Kodlama.io.Application.Features.Users.Dtos;
using Kodlama.io.Application.Features.Users.EntityBaseDependency;
using Kodlama.io.Application.Features.Users.Helpers;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Auths.Commands.Register
{
    public class RegisterUserCommand : IRequest<AuthUserModel>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }


        public class RegisterUserCommandHandler :
            UserDependResolver,
            IRequestHandler<RegisterUserCommand, AuthUserModel>
        {
            readonly private ITokenHelper _tokenHelper;

            public RegisterUserCommandHandler(IUserRepository userRepository,
                IMapper mapper,
                UserBusinessRules roles,
                ITokenHelper tokenHelper) : base(userRepository, mapper, roles)
            {
                _tokenHelper = tokenHelper;
            }

            public async Task<AuthUserModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await Rules.UserEmailCanNotBeDublicatedWhenCreated(request.UserForRegisterDto.Email);
                User mappedUser = Mapper.Map<User>(request.UserForRegisterDto);

                User user = UserHelper.SetUserPasswordDatas(mappedUser, request.UserForRegisterDto.Password);
                UserHelper.SetUserStatusWhenCreated(user);
                UserHelper.DefaultAuthenticatorType(user);
                User addedUser = await UserRepository.AddAsync(user);
                AccessToken accesToken = _tokenHelper.CreateToken(user, new List<OperationClaim>());
                return new() { AccessToken = accesToken };
                ;
            }
        }

    }
}
