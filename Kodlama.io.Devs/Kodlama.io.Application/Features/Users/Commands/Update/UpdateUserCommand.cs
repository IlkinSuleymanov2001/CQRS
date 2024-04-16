using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Application.Features.Users.Commands.Create;
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

namespace Kodlama.io.Application.Features.Users.Commands.Update
{
    public  class UpdateUserCommand : IRequest<UpdatedUserDto>
    {
        public int  Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class UpdateUserCommandHandler :UserDependResolver, IRequestHandler<UpdateUserCommand, UpdatedUserDto>

        {
            public UpdateUserCommandHandler(
                IUserRepository userRepository,
                IMapper mapper,
                UserBusinessRoles roles) :
                base(userRepository, mapper, roles)
            {}

            public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                await Rules.UserEmailCanNotBeDublicatedWhenUpdated(request.Id ,request.Email);

                User mappedUser = Mapper.Map<User>(request);

                User user = UserHelper.SetUserPasswordDatas(mappedUser, request.Password);

                User updatedUser = await UserRepository.UpdateAsync(user);
                UpdatedUserDto userDto = Mapper.Map<UpdatedUserDto>(updatedUser);
                return userDto;
            }

        }
    }
}
