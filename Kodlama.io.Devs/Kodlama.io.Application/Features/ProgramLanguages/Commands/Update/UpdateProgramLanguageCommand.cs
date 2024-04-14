using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Services.Repositories;
using Language = Kodlama.io.Domain.Entities.ProgramLanguage;
using MediatR;
using Kodlama.io.Application.Features.ProgramLanguages.BaseEntityDependency;


namespace Kodlama.io.Application.Features.ProgramLanguages.Commands.Update
{
    public class UpdateProgramLanguageCommand : IRequest<UpdatedProgramLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramLanguageCommandHandler :
              ProgramLanguageDependResolver,
            IRequestHandler<UpdateProgramLanguageCommand, UpdatedProgramLanguageDto>
        {
            public UpdateProgramLanguageCommandHandler(IProgramLanguageRepository languageRepository, IMapper mapper, ProgramLanguageBusinessRules rules) : base(languageRepository, mapper, rules)
            {
            }

            public async Task<UpdatedProgramLanguageDto> Handle(UpdateProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                Language? language = await PLanguageRepository.GetAsync(b => b.Id == request.Id);
                Rules.ProgramLanguageSholudExistsWhenRequested(language);
                await Rules.LanguageNameCanNotBeDuplicatedWhenRequested(request.Name);
                language.Name = request.Name;

                Language updatedLanguage = await PLanguageRepository.UpdateAsync(language);
                UpdatedProgramLanguageDto updatedLanguageDto = Mapper.Map<UpdatedProgramLanguageDto>(updatedLanguage);

                return updatedLanguageDto;


            }
        }
    }
}
