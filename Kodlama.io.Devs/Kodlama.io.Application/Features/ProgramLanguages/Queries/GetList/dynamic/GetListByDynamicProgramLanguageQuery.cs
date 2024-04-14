using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguages.BaseEntityDependency;
using Kodlama.io.Application.Features.ProgramLanguages.Models;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using Language = Kodlama.io.Domain.Entities.ProgramLanguage;

namespace Kodlama.io.Application.Features.ProgramLanguages.Queries.GetList.dynamic
{
    public  class GetListByDynamicProgramLanguageQuery: IRequest<ProgramLanguageListModel>
    {

        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

            public class GetListByDynamicProgramLanguageQueryHandler :
                  ProgramLanguageDependResolver,
                IRequestHandler<GetListByDynamicProgramLanguageQuery, ProgramLanguageListModel>
            {
                public GetListByDynamicProgramLanguageQueryHandler(IProgramLanguageRepository languageRepository, IMapper mapper, ProgramLanguageBusinessRules rules) : base(languageRepository, mapper, rules)
                {
                }

                public async Task<ProgramLanguageListModel> Handle(GetListByDynamicProgramLanguageQuery request, CancellationToken cancellationToken)
                {
                    IPaginate<Language> paginate = await PLanguageRepository.
                                      GetListByDynamicAsync(
                                      dynamic:request.Dynamic,
                                      index: request.PageRequest.Page,
                                      size: request.PageRequest.PageSize);
                    ProgramLanguageListModel resposne = Mapper.Map<ProgramLanguageListModel>(paginate);
                    return resposne;
                }
            }
        }
    
}
