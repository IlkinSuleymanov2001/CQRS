using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Domain.Entities
{
    public  class ProgramLanguage:Entity
    {
        public string Name { get; set; }

        public ProgramLanguage()
        {
            
        }
        public ProgramLanguage(int id ,string name):this()
        {
            Id = id;
            Name = name;
        }
    }
}
