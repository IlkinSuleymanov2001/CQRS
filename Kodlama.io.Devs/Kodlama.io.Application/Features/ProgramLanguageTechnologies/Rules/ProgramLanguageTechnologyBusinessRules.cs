using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Update;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Rules
{
    public  class ProgramLanguageTechnologyBusinessRules
    {
        private readonly IProgramLanguageTechnologyRepository _technologyRepository;
        private readonly IProgramLanguageRepository _languageRepository;

        public ProgramLanguageTechnologyBusinessRules(
            IProgramLanguageTechnologyRepository technologyRepository,
            IProgramLanguageRepository languageRepository)
        {
            _technologyRepository = technologyRepository;
            _languageRepository = languageRepository;
        }


        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var  technology = await _technologyRepository.GetAsync(pl => pl.Name == name);
            if (technology != null)
            {
                throw new BusinessException("Technology  Name Exists");
            }
        }
        public async Task CheckTechnologyExistsWhenRequested(int  id)
        {
            var technologies  = await _technologyRepository.GetListAsync(pl => pl.Id == id);
            if (technologies.Count==0)
            {
                throw new BusinessException("technology doesnt not exists");
            }
        }

        public async Task CheckTechnologyExistsWhenRequested(string  name)
        {
            var technologies = await _technologyRepository.GetListAsync(pl => pl.Name == name);
            if (technologies.Count == 0)
            {
                throw new BusinessException("technology doesnt not exists");
            }
        }


        public async Task ProgramLanguageExistsWhenTechnologyUpdated(UpdateProgramLanguageTechnologyCommand request)
        {

            var  language =  await _languageRepository.GetAsync(c => c.Id == request.ProgramLanguageId);
            if (language == null)
            {
                throw new BusinessException("language doest not exists..");
            }
        }


    }
}
