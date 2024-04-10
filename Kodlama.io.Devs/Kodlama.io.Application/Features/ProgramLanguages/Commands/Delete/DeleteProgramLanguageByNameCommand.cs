using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguages.BaseEntityDependency;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguages.Commands.Delete
{
    public  class DeleteProgramLanguageByNameCommand:IRequest<DeleteProgramLanguageDto>
    {
        public string Name  { get; set; }


        public class DeleteProgramLanguageByNameCommandHandler : EntityDependResolver, IRequestHandler<DeleteProgramLanguageByNameCommand,
            DeleteProgramLanguageDto>
        {
            public DeleteProgramLanguageByNameCommandHandler(
                IPLanguageRepository languageRepository,
                IMapper mapper,
                ProgramLanguageBusinessRules rules) :
                base(languageRepository, mapper, rules)
            {}

            public async Task<DeleteProgramLanguageDto> Handle(DeleteProgramLanguageByNameCommand request, CancellationToken cancellationToken)
            {
                var deleteEntity = PLanguageRepository.Get(p => p.Name == request.Name);
                Rules.ProgramLanguageSholudExistsWhenRequested(deleteEntity);

                Domain.Entities.ProgramLanguage returnDeletedEntity = await PLanguageRepository.DeleteAsync(deleteEntity);
                DeleteProgramLanguageDto respone = Mapper.Map<DeleteProgramLanguageDto>(returnDeletedEntity);

                return respone;
            }
        }

    }
}
