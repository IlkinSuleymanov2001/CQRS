using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.SocialMedias.Commands.Create;
using Kodlama.io.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Application.Features.SocialMedias.Models;
using Kodlama.io.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.SocialMedias.Profiles
{
    public  class SocialMediaAutoMApper:Profile
    {

        public SocialMediaAutoMApper()
        {
            CreateMap<SocialMedia, CreatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, GetListSocialMediaDto>().ReverseMap();
            CreateMap<IPaginate<SocialMedia>, SocialMediaListModel>().ReverseMap();
        }
    }
}
