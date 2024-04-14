using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.BaseEntityDependency;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Dtos;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Rules;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Queries.GetById
{
    public  class GetByIdProgramLanguageTechnologyQuery:IRequest<GetByIdProgramLanguageTechnologyDto>
    {

        public int Id { get; set; }

        public class GetByIdProgramLanguageTechnologyQueryHandler :
            ProgramLanguageTechnologyDependResolver,
            IRequestHandler<GetByIdProgramLanguageTechnologyQuery, GetByIdProgramLanguageTechnologyDto>
        {
            public GetByIdProgramLanguageTechnologyQueryHandler(
                IProgramLanguageTechnologyRepository technologyRepository,
                IMapper mapper, 
                ProgramLanguageTechnologyBusinessRules rules) 
                : base(technologyRepository, mapper, rules)
            {
            }

            public async Task<GetByIdProgramLanguageTechnologyDto> Handle(GetByIdProgramLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                await Rules.CheckTechnologyExistsWhenRequested(request.Id);
                var technology = await TechnologyRepository.GetByIdFullTechnologyData(request.Id);
                var response  = Mapper.Map<GetByIdProgramLanguageTechnologyDto>(technology);
                return response;
            }
        }
    }
}
