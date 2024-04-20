using Core.Persistence.Repositories;
using Kodlama.io.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Services.Repositories
{
    public interface ISocialMediaRepository: IRepository<SocialMedia>, IAsyncRepository<SocialMedia>
    {
    }
}
