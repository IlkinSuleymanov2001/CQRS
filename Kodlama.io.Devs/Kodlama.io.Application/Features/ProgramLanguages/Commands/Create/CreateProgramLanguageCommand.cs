using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguage.Dtos;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguages.BaseEntityDependency;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using Language = Kodlama.io.Domain.Entities.ProgramLanguage;


namespace Kodlama.io.Application.Features.ProgramLanguage.Commands.Create
{
    public  class CreateProgramLanguageCommand :IRequest<CreateProgramLanguageDto>
    {
        public string  Name { get; set; }

        public class CreateProgramLanguageCommandHandler : 
            ProgramLanguageDependResolver,
            IRequestHandler<CreateProgramLanguageCommand, CreateProgramLanguageDto>
        {
            public CreateProgramLanguageCommandHandler(IProgramLanguageRepository languageRepository, IMapper mapper, ProgramLanguageBusinessRules rules) : base(languageRepository, mapper, rules)
            {
            }

            public async Task<CreateProgramLanguageDto> Handle(CreateProgramLanguageCommand request, 
                CancellationToken cancellationToken)
            {
                
                await Rules.LanguageNameCanNotBeDuplicatedWhenRequested(request.Name);

                var mappedPlanguage = Mapper.Map<Language>(request);
                Language pLanguage = await PLanguageRepository.AddAsync(mappedPlanguage);
                CreateProgramLanguageDto ProgramLanguageDto = Mapper.Map<CreateProgramLanguageDto>(pLanguage);

                return ProgramLanguageDto;
            }
        }
    }
}
