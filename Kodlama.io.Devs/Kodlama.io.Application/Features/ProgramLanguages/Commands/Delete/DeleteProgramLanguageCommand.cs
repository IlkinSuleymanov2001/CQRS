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

namespace Kodlama.io.Application.Features.ProgramLanguages.Commands.Delete
{
    public  class DeleteProgramLanguageCommand:IRequest<DeleteProgramLanguageDto>
    {
        public int Id { get; set; }
     /*   public string? Name { get; set; }*/
       
        public class DeleteProgramLanguageCommandHandler : EntityDependResolver, 
            IRequestHandler<DeleteProgramLanguageCommand,  DeleteProgramLanguageDto>
        {
            public DeleteProgramLanguageCommandHandler(IPLanguageRepository languageRepository, IMapper mapper, ProgramLanguageBusinessRules rules)
                : base(languageRepository, mapper, rules){}

            public async Task<DeleteProgramLanguageDto> Handle(DeleteProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                var deleteEntity = PLanguageRepository.Get(p=>p.Id==request.Id);
                Rules.ProgramLanguageSholudExistsWhenRequested(deleteEntity);
                Domain.Entities.ProgramLanguage returnDeletedEntity = await PLanguageRepository.DeleteAsync(deleteEntity);
                DeleteProgramLanguageDto respone  = Mapper.Map<DeleteProgramLanguageDto>(returnDeletedEntity);
                return respone;
            }
        }
    }
}
