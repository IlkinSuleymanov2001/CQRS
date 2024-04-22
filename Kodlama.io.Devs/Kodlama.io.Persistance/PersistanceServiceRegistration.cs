using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Persistance.Contexts;
using Kodlama.io.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Persistance
{
    public static class PersistanceServiceRegistration
    {

        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,
            IConfiguration configuration) 
        {
            services.AddDbContext<KodlamaIoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Kodlamaio"));
            });
            //all repository services using  in the  project 
            services.AddScoped<IProgramLanguageRepository,PorgramLanguageRepository>();
            services.AddScoped<IProgramLanguageTechnologyRepository, ProgramLanguageTechnologyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSocialMediaRepository, UserSocialMediaRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }
    }
}
