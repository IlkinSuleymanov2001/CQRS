using Kodlama.io.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Kodlama.io.Persistance.Contexts
{
    public  class KodlamaIoContext: DbContext
    {

        public IConfiguration Configuration { get; set; }
        public DbSet<ProgramLanguage> ProgramLanguages { get; set; }
        public DbSet<ProgramLanguageTechnology> ProgramLanguagesTechnologies { get; set; }    

        public KodlamaIoContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramLanguage>(a => {
                a.ToTable("ProgramLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.ProgramLanguageTechnology);
            });

            modelBuilder.Entity<ProgramLanguageTechnology>(a => {
                a.ToTable("ProgramLanguageTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgramLanguageId).HasColumnName("ProgramLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p=>p.ProgramLanguage);
            });

            ProgramLanguage[] programLanguageDataSeed = { new(1,"C#") ,new(2,"java")  };
            modelBuilder.Entity<ProgramLanguage>().HasData(programLanguageDataSeed);

            ProgramLanguageTechnology[] programLanguageTechnologyDataSeed = { new(1, "entityFramework",1),
                new(2, "spring Boot",2) };
            modelBuilder.Entity<ProgramLanguageTechnology>().HasData(programLanguageTechnologyDataSeed);
        }


    }
}
