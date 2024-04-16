using AutoMapper;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.EntityBaseDependency
{
    public class UserDependResolver
    {
        protected IUserRepository UserRepository { get; set; }
        protected IMapper Mapper { get; set; }
        protected UserBusinessRoles Rules { get; set; }


        public UserDependResolver(IUserRepository userRepository, IMapper mapper, UserBusinessRoles roles)
        {
            UserRepository = userRepository;
            Mapper = mapper;
            Rules = roles;
        }

     
    }
}
