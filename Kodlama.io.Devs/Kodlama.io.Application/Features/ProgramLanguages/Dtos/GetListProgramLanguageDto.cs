using Kodlama.io.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguages.Dtos
{
    public  class GetListProgramLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
