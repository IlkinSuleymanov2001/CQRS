using Core.Security.Entities;
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
        public DbSet<UserSocialMedia> UserSocialMedias { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }


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
                a.HasOne(p => p.ProgramLanguage);
            });
            modelBuilder.Entity<User>(a => {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.HasMany(p => p.UserOperationClaims);
                a.HasMany(p => p.RefreshTokens);
            });

            modelBuilder.Entity<UserOperationClaim>(a => {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                a.HasOne(p => p.User);
                a.HasOne(p => p.OperationClaim);
            });

            modelBuilder.Entity<OperationClaim>(a => {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<RefreshToken>(a => {
                a.ToTable("RefreshTokens").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.Token).HasColumnName("Token");
                a.Property(p => p.Expires).HasColumnName("Expires");
                a.Property(p => p.Created).HasColumnName("Created");
                a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                a.Property(p => p.Revoked).HasColumnName("Revoked");
                a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                a.HasOne(p => p.User);
            });

            modelBuilder.Entity<EmailAuthenticator>(a => {
                a.ToTable("EmailAuthenticators").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.ActivationKey).HasColumnName("ActivationKey");
                a.Property(p => p.IsVerified).HasColumnName("IsVerified");
                a.HasOne(p => p.User);
            });

            modelBuilder.Entity<OtpAuthenticator>(a => {
                a.ToTable("OtpAuthenticators").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.SecretKey).HasColumnName("SecretKey");
                a.Property(p => p.IsVerified).HasColumnName("IsVerified");
                a.HasOne(p => p.User);
            });

            modelBuilder.Entity<UserSocialMedia>(a => {
                a.ToTable("UserSocialMedias").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.SocialMediaId).HasColumnName("SocialMediaId");
                a.Property(p => p.SocialMediaLink).HasColumnName("SocialMediaLink");
                a.HasOne(p => p.User);
                a.HasOne(p => p.SocialMedia);
            });

            modelBuilder.Entity<SocialMedia>(a => {
                a.ToTable("SocialMedias").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.SocialMediaName).HasColumnName("SocialMediaName");
            });

            ProgramLanguage[] programLanguageDataSeed = { new(1,"C#") ,new(2,"java")  };
            modelBuilder.Entity<ProgramLanguage>().HasData(programLanguageDataSeed);

            ProgramLanguageTechnology[] programLanguageTechnologyDataSeed = { new(1, "entityFramework",1),
                new(2, "spring Boot",2) };
            modelBuilder.Entity<ProgramLanguageTechnology>().HasData(programLanguageTechnologyDataSeed);
        }


    }
}
