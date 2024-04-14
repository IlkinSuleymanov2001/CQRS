using Core.Persistence.Paging;
using Kodlama.io.Application.Features.ProgramLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.ProgramLanguages.Models
{
    public  class ProgramLanguageListModel:BasePageableModel
    {
        public IList<GetListProgramLanguageDto> Items { get; set; }
    }
}
