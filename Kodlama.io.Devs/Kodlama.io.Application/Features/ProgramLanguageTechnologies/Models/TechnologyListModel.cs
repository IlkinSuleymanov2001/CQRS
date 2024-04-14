using Core.Persistence.Paging;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguageTechnologies.Models
{
    public  class TechnologyListModel:BasePageableModel
    {
        public IList<GetListProgramLanguageTechnologyDto> Items { get; set; }
    }
}
