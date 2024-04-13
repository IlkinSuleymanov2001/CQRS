using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguages.Models;
using Kodlama.io.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Language = Kodlama.io.Domain.Entities.ProgramLanguage;

namespace Kodlama.io.Application.Features.ProgramLanguages.Queries.GetAll
{
    public  class GetAllProgramLanguageQuery:IRequest<ProgramLanguageListModel> 
    {

        public PageRequest  PageRequest { get; set; }

        public class GetAllProgramLanguageQueryHandler : IRequestHandler<GetAllProgramLanguageQuery, ProgramLanguageListModel>
        {
            private readonly IProgramLanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _rules;

            public GetAllProgramLanguageQueryHandler(
                IProgramLanguageRepository languageRepository,
                IMapper mapper,
                ProgramLanguageBusinessRules rules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<ProgramLanguageListModel> Handle(GetAllProgramLanguageQuery request, CancellationToken cancellationToken)
            {
              IPaginate<Language> paginate =  await  _languageRepository.
                                GetListAsync(
                               // include:ef=>ef.Include(c=>c.ProgramLanguageTechnology),
                                index: request.PageRequest.Page,
                                size: request.PageRequest.PageSize);
              ProgramLanguageListModel resposne  = _mapper.Map<ProgramLanguageListModel>(paginate);
                return resposne;
            }
        }
    }
}
