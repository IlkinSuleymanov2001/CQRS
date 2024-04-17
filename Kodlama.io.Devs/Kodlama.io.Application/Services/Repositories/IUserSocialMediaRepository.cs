using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Services.Repositories
{
    public interface IUserSocialMediaRepository: IRepository<UserSocialMedia>, IAsyncRepository<UserSocialMedia>
    {
    }
}
