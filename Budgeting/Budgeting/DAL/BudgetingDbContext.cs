using Budgeting.Model;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.DAL
{
    public class BudgetingDbContext : DbContext
    {
        public BudgetingDbContext(DbContextOptions<BudgetingDbContext> options) : base(options)    
        {
        }
        public DbSet<CostItem> CostItems { get; set; }
        public DbSet<CostPeriod> CostPeriods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostPeriod>()
                .HasMany(c => c.CostItems)
                .WithOne(c => c.CostPeriod)
                .HasForeignKey(c => c.CostPeriodId);

            var seeder = new Seeder(modelBuilder);
            seeder.SeedTestData();
        }
    }
}
