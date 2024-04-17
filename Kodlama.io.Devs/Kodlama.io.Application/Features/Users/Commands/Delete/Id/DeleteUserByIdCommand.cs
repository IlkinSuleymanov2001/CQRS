using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
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

namespace Kodlama.io.Application.Features.Users.Commands.Delete.Id
{
    public  class DeleteUserByIdCommand :IRequest<DeletedUserDto>
    {

        public int Id { get; set; }

        public class DeleteUserCommandHandler : 
            UserDependResolver,
            IRequestHandler<DeleteUserByIdCommand, DeletedUserDto>
        {
            public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules roles) : base(userRepository, mapper, roles)
            {
            }

            public async Task<DeletedUserDto> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
            {
                User user = await Rules.UserExistsWhenRequested(request.Id);
                User deletedUser = await UserRepository.DeleteAsync(user);
                DeletedUserDto userDto = Mapper.Map<DeletedUserDto>(deletedUser);

                return userDto;

            }
        }
    }
}
