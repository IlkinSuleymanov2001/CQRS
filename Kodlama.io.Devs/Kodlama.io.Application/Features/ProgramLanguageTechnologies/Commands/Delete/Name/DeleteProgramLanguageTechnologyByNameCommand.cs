using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.BaseEntityDependency;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Dtos;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Rules;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Commands.Delete.Name
{
    public class DeleteProgramLanguageTechnologyByNameCommand :
       IRequest<DeleteProgramLanguageTechnologyDto>
    {
        public string  Name { get; set; }

        public class DeleteProgramLanguageTechnologyCommandHandler :
            ProgramLanguageTechnologyDependResolver,
            IRequestHandler<DeleteProgramLanguageTechnologyByNameCommand, DeleteProgramLanguageTechnologyDto>
        {
            public DeleteProgramLanguageTechnologyCommandHandler(IProgramLanguageTechnologyRepository technologyRepository, IMapper mapper, ProgramLanguageTechnologyBusinessRules rules) : base(technologyRepository, mapper, rules)
            {
            }

            public async Task<DeleteProgramLanguageTechnologyDto> Handle(DeleteProgramLanguageTechnologyByNameCommand request, CancellationToken cancellationToken)
            {
                await Rules.CheckTechnologyExistsWhenRequested(request.Name);
                var entity  = await TechnologyRepository.GetByNameFullTechnologyData(request.Name);
                await TechnologyRepository.DeleteAsync(entity);
                DeleteProgramLanguageTechnologyDto dto = Mapper.Map<DeleteProgramLanguageTechnologyDto>(entity);

                return dto;
            }
        }

    }
}
