using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguages.BaseEntityDependency;
using Kodlama.io.Application.Features.ProgramLanguages.Models;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Language = Kodlama.io.Domain.Entities.ProgramLanguage;

namespace Kodlama.io.Application.Features.ProgramLanguages.Queries.GetAll
{
    public  class GetListProgramLanguageQuery:IRequest<ProgramLanguageListModel> 
    {

        public PageRequest  PageRequest { get; set; }

        public class GetAllProgramLanguageQueryHandler :
              ProgramLanguageDependResolver,
            IRequestHandler<GetListProgramLanguageQuery, ProgramLanguageListModel>
        {
            public GetAllProgramLanguageQueryHandler(IProgramLanguageRepository languageRepository, IMapper mapper, ProgramLanguageBusinessRules rules) : base(languageRepository, mapper, rules)
            {
            }

            public async Task<ProgramLanguageListModel> Handle(GetListProgramLanguageQuery request, CancellationToken cancellationToken)
            {
              IPaginate<Language> paginate =  await PLanguageRepository.
                                GetListAsync(
                                index: request.PageRequest.Page,
                                size: request.PageRequest.PageSize);
              ProgramLanguageListModel resposne  = Mapper.Map<ProgramLanguageListModel>(paginate);
                return resposne;
            }
        }
    }
}
