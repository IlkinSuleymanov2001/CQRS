using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.BaseEntityDependency;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Models;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Rules;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Queries.GetList.dynamic
{
    public  class GetListByDynamicProgramLanguageTechnologyQuery : IRequest<TechnologyListModel>
    {
            public PageRequest PageRequest { get; set; }
            public Dynamic Dynamic { get; set; }

            public class GetListByDynamicProgramLanguageTechnologyQueryHandler :
                ProgramLanguageTechnologyDependResolver,
                IRequestHandler<GetListByDynamicProgramLanguageTechnologyQuery, TechnologyListModel>
            {
                public GetListByDynamicProgramLanguageTechnologyQueryHandler(IProgramLanguageTechnologyRepository technologyRepository, IMapper mapper, ProgramLanguageTechnologyBusinessRules rules) : base(technologyRepository, mapper, rules)
                {
                }

                public async Task<TechnologyListModel> Handle(GetListByDynamicProgramLanguageTechnologyQuery request, CancellationToken cancellationToken)
                {
                    IPaginate<ProgramLanguageTechnology> paginate =
                          await TechnologyRepository.GetListByDynamicAsync( 
                          dynamic: request.Dynamic,
                          include: ef => ef.Include(c => c.ProgramLanguage),
                          index: request.PageRequest.Page,
                          size: request.PageRequest.PageSize
                          ); ;
                    var listModel = Mapper.Map<TechnologyListModel>(paginate);

                    return listModel;
                }
            }
        }

    
}
