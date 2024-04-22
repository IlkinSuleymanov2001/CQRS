using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Rules;
using Kodlama.io.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.BaseEntityDependency
{
    public  class ProgramLanguageTechnologyDependResolver
    {
        protected IProgramLanguageTechnologyRepository TechnologyRepository { get;  }
        protected IMapper Mapper { get; }
        protected ProgramLanguageTechnologyBusinessRules Rules { get; }
        public ProgramLanguageTechnologyDependResolver(
            IProgramLanguageTechnologyRepository technologyRepository,
            IMapper mapper, 
            ProgramLanguageTechnologyBusinessRules rules)
        {
            TechnologyRepository = technologyRepository;
            Mapper = mapper;
            Rules = rules;
        }
    }
}
