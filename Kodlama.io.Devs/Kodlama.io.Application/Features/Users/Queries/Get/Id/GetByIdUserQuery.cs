using AutoMapper;
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

namespace Kodlama.io.Application.Features.Users.Queries.Get.GetById
{
    public class GetByIdUserQuery : IRequest<GetSingleUserDto>
    {

        public int Id { get; set; }
        public class GetByIdUserQueryHandler : UserDependResolver, IRequestHandler<GetByIdUserQuery, GetSingleUserDto>
        {
            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules roles) : base(userRepository, mapper, roles)
            {
            }

            public async Task<GetSingleUserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                User user = await Rules.UserExistsWhenRequested(request.Id);
                return Mapper.Map<GetSingleUserDto>(user);

            }
        }
    }
}
