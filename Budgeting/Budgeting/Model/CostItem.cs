using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Budgeting.Model
{
    public class CostItem
    {
        public int CostItemId { get; set; }
        [Required, Range(Double.MinValue, Double.MaxValue)]
        public double Cost { get; set; }   //NOTE when the cost is lower than 0 it is a cost, and when it is higher than 0 it is earned money
        [Required]
        public DateTime DateOfCost { get; set; }
        public bool IsPaid { get; set; } = false;
        public string? Note { get; set; } 

        public int CostPeriodId { get; set; }
        public CostPeriod CostPeriod { get; set; }

    }
}
