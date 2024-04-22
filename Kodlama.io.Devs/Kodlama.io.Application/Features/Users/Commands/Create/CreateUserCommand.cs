using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Kodlama.io.Application.Features.Users.Dtos;
using Kodlama.io.Application.Features.Users.EntityBaseDependency;
using Kodlama.io.Application.Features.Users.Helpers;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Commands.Create
{
    public  class CreateUserCommand : IRequest<CreatedUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }


        public class CreateUserCommandHandler :
             UserDependResolver,
            IRequestHandler<CreateUserCommand, CreatedUserDto>

        {

            public CreateUserCommandHandler(
                IUserRepository userRepository, 
                IMapper mapper,
                UserBusinessRules roles) : 
                base(userRepository, mapper, roles)
            {
            }

            public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await Rules.UserEmailCanNotBeDublicatedWhenRequested(email:request.Email);
                User mappedUser = Mapper.Map<User>(request);

                User user = UserHelper.SetUserPasswordDatas(mappedUser, request.Password);
                UserHelper.SetUserStatusWhenCreated(user);

                User addedUser = await UserRepository.AddAsync(user);

                CreatedUserDto userDto = Mapper.Map<CreatedUserDto>(addedUser);
                userDto.Password = request.Password;

                return userDto;
            }

        }
    }
}
