using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Persistance.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, KodlamaIoContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(KodlamaIoContext context) : base(context)
        {
        }
    }
}
