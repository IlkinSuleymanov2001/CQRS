using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguage.Dtos;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using Language = Kodlama.io.Domain.Entities.ProgramLanguage;


namespace Kodlama.io.Application.Features.ProgramLanguage.Commands.Create
{
    public  class CreateProgramLanguageCommand :IRequest<CreateProgramLanguageDto>
    {
        public string  Name { get; set; }

        public class CreateProgramLanguageCommandHandler : IRequestHandler<CreateProgramLanguageCommand, CreateProgramLanguageDto>
        {
            private readonly IProgramLanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _rules;

            public CreateProgramLanguageCommandHandler(
                IProgramLanguageRepository languageRepository,
                IMapper mapper,
                ProgramLanguageBusinessRules rules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreateProgramLanguageDto> Handle(CreateProgramLanguageCommand request, 
                CancellationToken cancellationToken)
            {
                await _rules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedPlanguage = _mapper.Map<Language>(request);
                Language pLanguage = await _languageRepository.AddAsync(mappedPlanguage);
                CreateProgramLanguageDto ProgramLanguageDto = _mapper.Map<CreateProgramLanguageDto>(pLanguage);

                return ProgramLanguageDto;
            }
        }
    }
}
