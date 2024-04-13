using Core.Persistence.Repositories;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using Kodlama.io.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Persistance.Repositories
{
    public class PorgramLanguageRepository : EfRepositoryBase<ProgramLanguage, KodlamaIoContext>,
        IProgramLanguageRepository
    {
        public PorgramLanguageRepository(KodlamaIoContext context) : base(context)
        {
        }
    }
}
