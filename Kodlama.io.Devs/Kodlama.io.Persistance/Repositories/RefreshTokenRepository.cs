using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Persistance.Contexts;

namespace Kodlama.io.Persistance.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, KodlamaIoContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(KodlamaIoContext context) : base(context)
        {
        }
    }
}
