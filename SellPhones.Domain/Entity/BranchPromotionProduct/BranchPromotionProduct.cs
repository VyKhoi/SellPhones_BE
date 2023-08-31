using CellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity
{
    [Table("BranchPromotionProduct")]
    public class BranchPromotionProduct : IAudit
    {
        public int Id { get; set; }

        public double DiscountRate { get; set; }

        public int IdBrandProductColorId { get; set; }

        public int IdPromotionId { get; set; }
        public DateTime? AddedTimestamp { get; set; }

        public DateTime? ChangedTimestamp { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public virtual BranchProductColor BrandProductColor { get; set; } = null!;

        public virtual Promotion Promotion { get; set; } = null!;
    }
}