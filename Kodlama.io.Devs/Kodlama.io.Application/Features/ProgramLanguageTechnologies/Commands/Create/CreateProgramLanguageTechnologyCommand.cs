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

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Create
{
    public  class CreateProgramLanguageTechnologyCommand : IRequest<CreateProgramLanguageTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgramLanguageId { get; set; }

        public class CreateProgramLanguageTechnologyCommandHandler :
            ProgramLanguageTechnologyDependResolver,
            IRequestHandler<CreateProgramLanguageTechnologyCommand, CreateProgramLanguageTechnologyDto>
        {
            public CreateProgramLanguageTechnologyCommandHandler(IProgramLanguageTechnologyRepository technologyRepository, IMapper mapper, ProgramLanguageTechnologyBusinessRules rules) : base(technologyRepository, mapper, rules)
            {
            }

            public async Task<CreateProgramLanguageTechnologyDto> Handle(CreateProgramLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                await Rules.TechnologyNameCanNotBeDuplicatedWhenRequested(request.Name);

                var entity  =  Mapper.Map<ProgramLanguageTechnology>(request);
                var addedEntity = await  TechnologyRepository.AddAsync(entity);
                ProgramLanguageTechnology? joinedEntity  = await TechnologyRepository.GetAsync(predicate: p => p.Id == addedEntity.Id,
                                              include: ef => ef.Include(c=>c.ProgramLanguage));
                CreateProgramLanguageTechnologyDto dto =  Mapper.Map<CreateProgramLanguageTechnologyDto>(joinedEntity);
                return dto;
            }
        }
    }
}
