using FluentValidation;
using Kodlama.io.Application.Features.ProgramLanguage.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguages.Commands.Create
{
    public  class CreateProgramLanguageValidator : 
        AbstractValidator<CreateProgramLanguageCommand>
    {

        public CreateProgramLanguageValidator() 
        {
            RuleFor(l => l.Name).NotEmpty();
            RuleFor(l => l.Name).MinimumLength(5);
        }
    }
}
