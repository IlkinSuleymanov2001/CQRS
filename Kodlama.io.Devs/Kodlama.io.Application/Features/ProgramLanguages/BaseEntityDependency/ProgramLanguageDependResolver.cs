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
    public abstract class ProgramLanguageDependResolver
    {
        protected virtual IProgramLanguageRepository PLanguageRepository { get; }
        protected virtual IMapper Mapper { get; }
        protected virtual ProgramLanguageBusinessRules Rules { get; }

        protected ProgramLanguageDependResolver(IProgramLanguageRepository languageRepository,
            IMapper mapper,
            ProgramLanguageBusinessRules rules)
        {
            PLanguageRepository = languageRepository;
            Mapper = mapper;
            Rules = rules;
        }



    }
}
