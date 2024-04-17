using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Application.Features.Users.EntityBaseDependency;
using Kodlama.io.Application.Features.Users.Models;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Queries.GetList
{
    public  class GetListUserQuery:IRequest<UserListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserQueryHandler : UserDependResolver, IRequestHandler<GetListUserQuery, UserListModel>
        {
            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules roles) : base(userRepository, mapper, roles)
            {
            }

            public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
               IPaginate<User> users =  await UserRepository.GetListAsync(index: request.PageRequest.Page, 
                                                              size: request.PageRequest.PageSize);
                return Mapper.Map<UserListModel>(users);
            }
        }
    }
}
