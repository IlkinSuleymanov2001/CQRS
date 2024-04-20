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
    public class SocialMediaRepository : EfRepositoryBase<SocialMedia, KodlamaIoContext>, ISocialMediaRepository
    {
        public SocialMediaRepository(KodlamaIoContext context) : base(context)
        {
        }
    }
}
