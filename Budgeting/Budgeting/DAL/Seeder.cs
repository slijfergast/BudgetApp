using Budgeting.Model;
using Microsoft.EntityFrameworkCore;

namespace Budgeting.DAL
{
    public class Seeder
    {
        private readonly ModelBuilder _modelBuilder;

        public Seeder(ModelBuilder builder)
        {
            _modelBuilder = builder;
        }

        public void SeedTestData()
        {
            //create a test period with 2 CostItems
            var costItemJan = new CostItem()
            {
                CostItemId = -2,
                Cost = 100,
                DateOfCost = new DateTime(2023, 01, 1)
            };
            var costItemDec = new CostItem()
            {
                CostItemId = -1,
                Cost = 100,
                DateOfCost = new DateTime(2023, 12, 31)
            };
            var costPeriod = new CostPeriod()
            {
                CostPeriodId = -1,
                Name = "test_item"
            };
            costItemJan.CostPeriodId = costPeriod.CostPeriodId;
            costItemDec.CostPeriodId = costPeriod.CostPeriodId;

            //seed this data
            _modelBuilder.Entity<CostItem>()
                .HasData(new CostItem[] { costItemJan, costItemDec });

            _modelBuilder.Entity<CostPeriod>()
                .HasData(new CostPeriod[] { costPeriod });
        }
    }
}
