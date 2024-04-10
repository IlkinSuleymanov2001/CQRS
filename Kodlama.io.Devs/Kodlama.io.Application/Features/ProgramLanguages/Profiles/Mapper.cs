using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.ProgramLanguage.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguage.Dtos;
using Kodlama.io.Application.Features.ProgramLanguages.Commands.Delete;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Features.ProgramLanguages.Models;
using PLanguage = Kodlama.io.Domain.Entities.ProgramLanguage;

namespace Kodlama.io.Application.Features.ProgramLanguages.Profiles
{
    public  class Mapper : Profile
    {

        public Mapper()
        {
            CreateMap<PLanguage, CreateProgramLanguageCommand>().ReverseMap();
            CreateMap<PLanguage, CreateProgramLanguageDto>().ReverseMap();
            CreateMap<IPaginate<PLanguage>, ProgramLanguageListModel>().ReverseMap();
            CreateMap<PLanguage, GetAllProgramLanguageDto>().ReverseMap();
            CreateMap<PLanguage, GetByIdProgramLanguageDto>().ReverseMap();
            CreateMap<PLanguage, DeleteProgramLanguageDto>().ReverseMap();
            CreateMap<PLanguage, DeleteProgramLanguageCommand>().ReverseMap();
            CreateMap<PLanguage, UpdatedProgramLanguageDto>().ReverseMap();


        }
    }
}
