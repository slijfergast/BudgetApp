using System.ComponentModel.DataAnnotations;

namespace Budgeting.Model
{
    //CostPeriod is a collection of multiple costItems, could not really think of a more descriptive name for this class.
    public class CostPeriod
    {
        public int CostPeriodId { get; set; }
        [Required, MinLength(1), MaxLength(30)]
        public string Name { get; set; }
        public ICollection<CostItem> CostItems { get; } = new List<CostItem>();
    }
}
