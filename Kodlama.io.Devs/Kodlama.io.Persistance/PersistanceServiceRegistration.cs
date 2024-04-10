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

            services.AddScoped<IPLanguageRepository,PLanguageRepository>();

            return services;
        }
    }
}
