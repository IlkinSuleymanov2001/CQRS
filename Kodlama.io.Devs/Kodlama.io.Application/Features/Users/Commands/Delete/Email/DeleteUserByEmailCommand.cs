using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Application.Features.Users.Commands.Delete.Id;
using Kodlama.io.Application.Features.Users.Dtos;
using Kodlama.io.Application.Features.Users.EntityBaseDependency;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Commands.Delete.Gmail
{
    public class DeleteUserByEmailCommand:IRequest<DeletedUserDto>
    {
        public string Email { get; set; } = string.Empty;


        public class DeleteUserCommandHandler :
            UserDependResolver,
            IRequestHandler<DeleteUserByEmailCommand, DeletedUserDto>
        {
            public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRoles roles) : base(userRepository, mapper, roles)
            {
            }

            public async Task<DeletedUserDto> Handle(DeleteUserByEmailCommand request, CancellationToken cancellationToken)
            {
                User user = await Rules.UserExistsWhenRequested(request.Email);
                User deletedUser = await UserRepository.DeleteAsync(user);
                DeletedUserDto userDto = Mapper.Map<DeletedUserDto>(deletedUser);

                return userDto;

            }
        }
    }
}
