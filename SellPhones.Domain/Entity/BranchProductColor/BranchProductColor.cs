using CellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity
{
    [Table("BranchProductColor")]
    public class BranchProductColor : IAudit
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int BranchId { get; set; }

        public int ProductColorId { get; set; }
        public DateTime? AddedTimestamp { get; set; }

        public DateTime? ChangedTimestamp { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<BranchPromotionProduct> BranchPromotionProducts { get; } = new List<BranchPromotionProduct>();

        public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

        public virtual Branch Branch { get; set; } = null!;

        public virtual ProductColor ProductColor { get; set; } = null!;
    }
}