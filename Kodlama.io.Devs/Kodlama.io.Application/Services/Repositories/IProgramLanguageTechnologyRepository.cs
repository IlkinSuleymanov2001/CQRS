using Core.Persistence.Repositories;
using Kodlama.io.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Services.Repositories
{
    public  interface  IProgramLanguageTechnologyRepository: IRepository<ProgramLanguageTechnology>,
        IAsyncRepository<ProgramLanguageTechnology>
    {
        public Task<ProgramLanguageTechnology> GetByIdFullTechnologyData(int id);

        public Task<ProgramLanguageTechnology> GetByNameFullTechnologyData(string  name);
    }
}
