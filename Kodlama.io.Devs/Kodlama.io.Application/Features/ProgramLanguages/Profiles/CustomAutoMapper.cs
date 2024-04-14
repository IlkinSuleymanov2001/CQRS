using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.ProgramLanguage.Commands.Create;
using Kodlama.io.Application.Features.ProgramLanguage.Dtos;
using Kodlama.io.Application.Features.ProgramLanguages.Commands.Delete.Id;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Features.ProgramLanguages.Models;
using PLanguage = Kodlama.io.Domain.Entities.ProgramLanguage;

namespace Kodlama.io.Application.Features.ProgramLanguages.Profiles
{
    public  class CustomAutoMapper : Profile
    {

        public CustomAutoMapper()
        {
            CreateMap<PLanguage, CreateProgramLanguageCommand>().ReverseMap();
            CreateMap<PLanguage, CreateProgramLanguageDto>().ReverseMap();
            CreateMap<IPaginate<PLanguage>, ProgramLanguageListModel>().ReverseMap();
            CreateMap<PLanguage, GetListProgramLanguageDto>().ReverseMap();
            CreateMap<PLanguage, GetByIdProgramLanguageDto>().ReverseMap();
            CreateMap<PLanguage, DeleteProgramLanguageDto>().ReverseMap();
            CreateMap<PLanguage, DeleteProgramLanguageByIdCommand>().ReverseMap();
            CreateMap<PLanguage, UpdatedProgramLanguageDto>().ReverseMap();


        }
    }
}
