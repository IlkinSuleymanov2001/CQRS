using Core.Persistence.Repositories;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using Kodlama.io.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Persistance.Repositories
{
    public class ProgramLanguageTechnologyRepository : EfRepositoryBase<ProgramLanguageTechnology, KodlamaIoContext>,
        IProgramLanguageTechnologyRepository
    {
        public ProgramLanguageTechnologyRepository(KodlamaIoContext context) : base(context)
        {
        }

        public async Task<ProgramLanguageTechnology> GetByIdFullTechnologyData(int id)
        {
            ProgramLanguageTechnology? technology  = await GetAsync(p => p.Id ==id,
                             include: ef => ef.Include(c => c.ProgramLanguage));

           return technology;
        }
    }
}
