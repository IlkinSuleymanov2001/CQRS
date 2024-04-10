using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguages.BaseEntityDependency;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguages.Queries.GetById
{
    public class GetByIdProgramLanguageQuery:IRequest<GetByIdProgramLanguageDto>
    {

        public int Id { get; set; }

        public class GetByIdProgramLanguageQueryHandler :EntityDependResolver,
            IRequestHandler<GetByIdProgramLanguageQuery, GetByIdProgramLanguageDto>
        {
            public GetByIdProgramLanguageQueryHandler(IPLanguageRepository languageRepository, IMapper mapper, ProgramLanguageBusinessRules rules) 
                : base(languageRepository, mapper, rules)
            {
            }
            public async Task<GetByIdProgramLanguageDto> Handle(GetByIdProgramLanguageQuery request, CancellationToken cancellationToken)
            {
               var entityMapped  =  await  PLanguageRepository.GetAsync(pl => pl.Id == request.Id);
                GetByIdProgramLanguageDto dto = Mapper.Map<GetByIdProgramLanguageDto>(entityMapped);
                return dto;
            }
        }
    }
}
