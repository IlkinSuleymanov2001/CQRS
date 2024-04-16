using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Application.Features.Users.Commands.Create;
using Kodlama.io.Application.Features.Users.Commands.Delete.Id;
using Kodlama.io.Application.Features.Users.Commands.Update;
using Kodlama.io.Application.Features.Users.Dtos;
using Kodlama.io.Application.Features.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Profiles
{
    public  class UserAutoMapper:Profile
    {

        public UserAutoMapper()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreatedUserDto>().ReverseMap();

            CreateMap<User, DeletedUserDto>().ReverseMap();
            CreateMap<User, DeleteUserByIdCommand>().ReverseMap();

            CreateMap<User, UpdatedUserDto>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();

            CreateMap<User, GetSingleUserDto>().ReverseMap();

            CreateMap<IPaginate<User>, UserListModel>().ReverseMap();
            CreateMap<User, GetListUserDto>().ReverseMap();


        }
    }
}
