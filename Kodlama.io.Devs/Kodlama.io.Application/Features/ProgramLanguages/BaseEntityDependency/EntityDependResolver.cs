using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguages.BaseEntityDependency
{
    public abstract class EntityDependResolver
    {
        protected virtual  IPLanguageRepository PLanguageRepository { get; }
        protected virtual IMapper Mapper { get; }
        protected virtual ProgramLanguageBusinessRules Rules { get; }

        protected EntityDependResolver(IPLanguageRepository languageRepository,
            IMapper mapper,
            ProgramLanguageBusinessRules rules)
        {
            PLanguageRepository = languageRepository;
            Mapper = mapper;
            Rules = rules;
        }


      
    }
}
