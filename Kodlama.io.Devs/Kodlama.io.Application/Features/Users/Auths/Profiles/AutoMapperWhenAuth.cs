using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;

namespace Kodlama.io.Application.Features.Users.Auths.Profiles
{
    public class AutoMapperWhenAuth : Profile
    {

        public AutoMapperWhenAuth()
        {
            CreateMap<User, UserForRegisterDto>().ReverseMap();

        }
    }
}
