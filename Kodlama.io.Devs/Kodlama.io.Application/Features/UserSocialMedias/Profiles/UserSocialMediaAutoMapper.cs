using AutoMapper;
using Kodlama.io.Application.Features.UserSocialMedias.Commands.Create;
using Kodlama.io.Application.Features.UserSocialMedias.Dtos;
using Kodlama.io.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.UserSocialMedias.Profiles
{
    public  class UserSocialMediaAutoMapper :Profile
    {

        public UserSocialMediaAutoMapper()
        {
            CreateMap<UserSocialMedia, CreateUserSocialMediaCommand>().ReverseMap();
            CreateMap<UserSocialMedia, CreateUserSocialMediaDto>().ReverseMap();

            CreateMap<UserSocialMedia, GetByIdSocialMediaDto>().ReverseMap();

        }
    }
}
