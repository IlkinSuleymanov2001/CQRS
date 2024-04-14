using AutoMapper;
using Core.Application.Requests;
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

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Queries.GetList
{
    public  class GetListProgramLanguageTechnologyQuery :IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgramLanguageTechnologyQueryHandler :
            ProgramLanguageTechnologyDependResolver,
            IRequestHandler<GetListProgramLanguageTechnologyQuery, TechnologyListModel>
        {
            public GetListProgramLanguageTechnologyQueryHandler(IProgramLanguageTechnologyRepository technologyRepository, IMapper mapper, ProgramLanguageTechnologyBusinessRules rules) : base(technologyRepository, mapper, rules)
            {
            }

            public async Task<TechnologyListModel> Handle(GetListProgramLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
              IPaginate<ProgramLanguageTechnology> paginate =  
                    await TechnologyRepository.GetListAsync(
                    include:ef=>ef.Include(c=>c.ProgramLanguage),
                    index:request.PageRequest.Page,
                    size:request.PageRequest.PageSize
                    );;

                var getListModel = Mapper.Map<TechnologyListModel>(paginate);

                return getListModel;
            }
        }
    }
}
