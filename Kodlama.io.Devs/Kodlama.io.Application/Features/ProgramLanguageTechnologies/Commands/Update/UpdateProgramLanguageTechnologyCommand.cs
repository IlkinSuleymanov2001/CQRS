using AutoMapper;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.BaseEntityDependency;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Dtos;
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

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Update
{
    public  class UpdateProgramLanguageTechnologyCommand:IRequest<UpdateProgramLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgramLanguageId { get; set; }

        public class UpdateProgramLanguageTechnologyConmmandHandler :
            ProgramLanguageTechnologyDependResolver,
            IRequestHandler<UpdateProgramLanguageTechnologyCommand,
             UpdateProgramLanguageTechnologyDto>
        {
            public UpdateProgramLanguageTechnologyConmmandHandler(IProgramLanguageTechnologyRepository technologyRepository, IMapper mapper, ProgramLanguageTechnologyBusinessRules rules) : base(technologyRepository, mapper, rules)
            {
            }

            public async Task<UpdateProgramLanguageTechnologyDto> Handle(
                UpdateProgramLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {

                await Rules.ProgramLanguageExistsWhenTechnologyUpdated(request);

                ProgramLanguageTechnology mappedEntity = Mapper.Map<ProgramLanguageTechnology>(request);
                ProgramLanguageTechnology updatedEntity = await TechnologyRepository.UpdateAsync(mappedEntity);
                ProgramLanguageTechnology? joinedEntity = await TechnologyRepository.GetAsync(c => c.Id == updatedEntity.Id,
                    include: ef => ef.Include(c => c.ProgramLanguage));
                var dto =  Mapper.Map<UpdateProgramLanguageTechnologyDto>(joinedEntity);
                
                return dto; 
            }
        }
    }
}
