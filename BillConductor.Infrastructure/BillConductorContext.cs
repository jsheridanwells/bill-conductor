using BillConductor.Core.HealthCheck;
using Microsoft.EntityFrameworkCore;

namespace BillConductor.Infrastructure
{
    public class BillConductorContext : DbContext
    {
        public BillConductorContext(DbContextOptions<BillConductorContext> opts) : base(opts) { }

        public DbSet<HealthCheck> HealthChecks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HealthCheck>().HasNoKey();

            modelBuilder.Entity<HealthCheck>()
                .Property(hc => hc.Uid)
                .HasConversion<string>(uid => uid.Value.ToString(), dbUid => new Uid { Value = new Guid(dbUid) });

            modelBuilder.Entity<HealthCheck>()
                .Property(hc => hc.HealthCheckDate)
                .HasConversion<DateTime>(hcDate => hcDate.Value, dbHcDate => new HealthCheckDate { Value = dbHcDate });
        }
    }
}
