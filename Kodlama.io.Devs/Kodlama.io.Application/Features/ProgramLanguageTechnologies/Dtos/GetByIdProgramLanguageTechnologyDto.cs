using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Dtos
{
    public  class GetByIdProgramLanguageTechnologyDto
    {
        public int Id { get; set; }
        public int ProgramLanguageId { get; set; }
        public string Name { get; set; }
        public string ProgramLanguageName { get; set; }
    }
}
