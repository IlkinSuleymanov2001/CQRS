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
                //await Rules.CheckTechnologyExistsWhenRequested(request.Id);
                await Rules.ProgramLanguageExistsWhenTechnologyUpdated(request);
                await Rules.TechnologyNameCanNotBeDuplicatedWhenRequested(request.Name);

                var mappedEntity = Mapper.Map<ProgramLanguageTechnology>(request);
                var updatedEntity = await TechnologyRepository.UpdateAsync(mappedEntity);

                Rules.CheckNullRefereance(updatedEntity);

                var dto =Mapper.Map<UpdateProgramLanguageTechnologyDto>(updatedEntity);

                return dto; 
            }
        }
    }
}
