using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.ProgramLanguage.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Delete.Id;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Delete.Name;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Update;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Dtos;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Models;
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
            CreateMap<ProgramLanguageTechnology, UpdateProgramLanguageTechnologyDto>().ForMember(c => c.ProgramLanguageName, opt => opt.MapFrom(c => c.ProgramLanguage.Name)).ReverseMap();
            
            CreateMap<ProgramLanguageTechnology, GetByIdProgramLanguageTechnologyDto>().ForMember(c => c.ProgramLanguageName, opt => opt.MapFrom(c => c.ProgramLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<ProgramLanguageTechnology>, TechnologyListModel>().ReverseMap();
            CreateMap<ProgramLanguageTechnology, GetListProgramLanguageTechnologyDto>().ForMember(c => c.ProgramLanguageName, opt => opt.MapFrom(c => c.ProgramLanguage.Name)).ReverseMap();

        }
    }
}
