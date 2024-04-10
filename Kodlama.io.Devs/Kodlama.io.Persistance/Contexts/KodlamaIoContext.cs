using Kodlama.io.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Kodlama.io.Persistance.Contexts
{
    public  class KodlamaIoContext: DbContext
    {

        public IConfiguration Configuration { get; set; }
        public DbSet<ProgramLanguage> ProgramLanguages { get; set; }

        public KodlamaIoContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramLanguage>(a => {
                a.ToTable("ProgramLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });

            ProgramLanguage[] programLanguageDataSeed = { new(1,"C#") ,new(2,"java")  };
            modelBuilder.Entity<ProgramLanguage>().HasData(programLanguageDataSeed);

        }


    }
}
