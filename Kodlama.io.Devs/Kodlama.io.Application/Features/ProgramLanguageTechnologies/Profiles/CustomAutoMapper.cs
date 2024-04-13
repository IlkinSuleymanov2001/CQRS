﻿using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguage.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Delete.Id;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Delete.Name;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Update;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Dtos;
using Kodlama.io.Domain.Entities;

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Profiles
{
    public class CustomAutoMapper : Profile
    {
        public CustomAutoMapper()
        {
            CreateMap<ProgramLanguageTechnology, CreateProgramLanguageTechnologyCommand>().ReverseMap();
            CreateMap<ProgramLanguageTechnology, CreateProgramLanguageTechnologyDto>().ForMember(c => c.ProgramLanguageName,opt => opt.MapFrom(c => c.ProgramLanguage.Name)).ReverseMap();
            CreateMap<ProgramLanguageTechnology, DeleteProgramLanguageTechnologyDto>().ForMember(c => c.ProgramLanguageName,opt => opt.MapFrom(c => c.ProgramLanguage.Name)).ReverseMap();
            CreateMap<ProgramLanguageTechnology, UpdateProgramLanguageTechnologyCommand>().ReverseMap();
            CreateMap<ProgramLanguageTechnology, UpdateProgramLanguageTechnologyDto>().ForMember(c => c.ProgamLanguageName,opt => opt.MapFrom(c => c.ProgramLanguage.Name)).ReverseMap();
        }
    }
}