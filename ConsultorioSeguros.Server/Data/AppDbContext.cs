using ConsultorioSeguros.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioSeguros.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<InsurancePlan> InsurancePlans { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsurancePlan>(mdl =>
            {
                mdl.HasKey(c => c.Id);
                mdl.HasIndex(c => c.Code)
                    .IsUnique();
            });

            modelBuilder.Entity<Client>(mdl =>
            {
                mdl.HasKey(c => c.Id);
                mdl.HasIndex(c => c.IdentificationNumber)
                    .IsUnique();
            });

            modelBuilder.Entity<InsurancePolicy>(mdl =>
            {
                mdl.HasKey(c => c.Number);
            });

            modelBuilder.Entity<Client>()
                .HasMany(e => e.InsurancePlans)
                .WithMany()
                .UsingEntity<InsurancePolicy>();
        }
    }
}
