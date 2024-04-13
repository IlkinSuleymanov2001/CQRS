using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguages.BaseEntityDependency;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Features.ProgramLanguages.Queries.GetById;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguages.Commands.Delete.Id
{
    public class DeleteProgramLanguageByIdCommand : IRequest<DeleteProgramLanguageDto>
    {
        public int Id { get; set; }


        public class DeleteProgramLanguageCommandHandler : ProgramLanguageDependResolver,
            IRequestHandler<DeleteProgramLanguageByIdCommand, DeleteProgramLanguageDto>
        {
            public DeleteProgramLanguageCommandHandler(IProgramLanguageRepository languageRepository, IMapper mapper, ProgramLanguageBusinessRules rules)
                : base(languageRepository, mapper, rules) { }

            public async Task<DeleteProgramLanguageDto> Handle(DeleteProgramLanguageByIdCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.ProgramLanguage entity = PLanguageRepository.Get(p => p.Id == request.Id);
                Rules.ProgramLanguageSholudExistsWhenRequested(entity);
                Domain.Entities.ProgramLanguage deletedEntity = await PLanguageRepository.DeleteAsync(entity);
                DeleteProgramLanguageDto respone = Mapper.Map<DeleteProgramLanguageDto>(deletedEntity);
                return respone;
            }
        }
    }
}
