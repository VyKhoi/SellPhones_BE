using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public class BranchPromotionProduct : IAudit
    {
        public int Id { get; set; }

        public double DiscountRate { get; set; }

        public int IdBrandProductColorId { get; set; }

        public int IdPromotionId { get; set; }
        public DateTime? AddedTimestamp { get; set; }
     
        public DateTime? ChangedTimestamp { get; set; }
 

        public virtual BranchProductColor BrandProductColor { get; set; } = null!;

        public virtual Promotion Promotion { get; set; } = null!;
    }
}
