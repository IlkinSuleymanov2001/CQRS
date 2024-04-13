using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Domain.Entities
{
    public  class ProgramLanguageTechnology :Entity
    {
      

        public string  Name { get; set; }
        public int ProgramLanguageId { get; set; }
        public virtual ProgramLanguage? ProgramLanguage { get; set; }
        public ProgramLanguageTechnology()
        {
        }

        public ProgramLanguageTechnology(int id,
          string name, int programLanguageId):this()
        {
            Id = id;
            ProgramLanguageId = programLanguageId;
            Name = name;

        }

    }
}
