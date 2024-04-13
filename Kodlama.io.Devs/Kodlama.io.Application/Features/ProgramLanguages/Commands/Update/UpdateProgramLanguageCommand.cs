using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Services.Repositories;
using Language = Kodlama.io.Domain.Entities.ProgramLanguage;
using MediatR;


namespace Kodlama.io.Application.Features.ProgramLanguages.Commands.Update
{
    public class UpdateProgramLanguageCommand : IRequest<UpdatedProgramLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramLanguageCommandHandler : IRequestHandler<UpdateProgramLanguageCommand, UpdatedProgramLanguageDto>
        {
            private readonly IProgramLanguageRepository _pLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _rules;

            public UpdateProgramLanguageCommandHandler(
                IProgramLanguageRepository programmingLanguageRepository
                ,IMapper mapper,
                ProgramLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _pLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _rules = programmingLanguageBusinessRules;
            }

            public async Task<UpdatedProgramLanguageDto> Handle(UpdateProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                Language? language = await _pLanguageRepository.GetAsync(b => b.Id == request.Id);
                _rules.ProgramLanguageSholudExistsWhenRequested(language);
                await _rules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
                language.Name = request.Name;

                Language updatedLanguage = await _pLanguageRepository.UpdateAsync(language);
                UpdatedProgramLanguageDto updatedLanguageDto = _mapper.Map<UpdatedProgramLanguageDto>(updatedLanguage);

                return updatedLanguageDto;


            }
        }
    }
}
