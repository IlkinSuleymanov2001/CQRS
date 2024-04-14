using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
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

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Delete.Id
{
    public  class DeleteProgramLanguageTechnologyByIdCommand:
        IRequest<DeleteProgramLanguageTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteProgramLanguageTechnologyCommandHandler :
            ProgramLanguageTechnologyDependResolver,
            IRequestHandler<DeleteProgramLanguageTechnologyByIdCommand, DeleteProgramLanguageTechnologyDto>
        {
            public DeleteProgramLanguageTechnologyCommandHandler(IProgramLanguageTechnologyRepository technologyRepository, IMapper mapper, ProgramLanguageTechnologyBusinessRules rules) : base(technologyRepository, mapper, rules)
            {
            }

            public async Task<DeleteProgramLanguageTechnologyDto> Handle(DeleteProgramLanguageTechnologyByIdCommand request, CancellationToken cancellationToken)
            {
                await Rules.CheckTechnologyExistsWhenRequested(request.Id);
                var entity = await TechnologyRepository.GetByIdFullTechnologyData(request.Id);
                var deletedEntity =await TechnologyRepository.DeleteAsync(entity);

                DeleteProgramLanguageTechnologyDto dto = Mapper.Map<DeleteProgramLanguageTechnologyDto>(entity);

                return dto;
            }
        }

    }
}
