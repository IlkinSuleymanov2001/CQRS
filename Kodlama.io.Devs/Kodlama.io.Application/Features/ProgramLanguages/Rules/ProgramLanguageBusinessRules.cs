using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguage.Rules
{
    public class ProgramLanguageBusinessRules
    {
        private readonly IProgramLanguageRepository _pLanguageRepository;

        public ProgramLanguageBusinessRules(IProgramLanguageRepository pLanguageRepository)
        {
            _pLanguageRepository = pLanguageRepository;
        }

        public async  Task  LanguageNameCanNotBeDuplicatedWhenInserted(string languageName ) 
        {
           Domain.Entities.ProgramLanguage langauge =  await _pLanguageRepository.GetAsync(pl => pl.Name == languageName);
            if (langauge != null)
            {
                throw new BusinessException("Programming Language Name Exists");
            }
        }

        public void ProgramLanguageSholudExistsWhenRequested(Domain.Entities.ProgramLanguage programLanguage)
        {
            if (programLanguage == null)
            {
                throw new BusinessException("Programming Language Doesnt exists");
            }
        }



    }
}
