using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{

    public class BranchProductColor : IAudit
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int BranchId { get; set; }

        public int ProductColorId { get; set; }
        public DateTime? AddedTimestamp { get; set; }
   
        public DateTime? ChangedTimestamp { get; set; }
  

        public virtual ICollection<BranchPromotionProduct> BranchPromotionProducts { get; } = new List<BranchPromotionProduct>();

        public virtual ICollection<Orderdetail> Orderdetails { get; } = new List<Orderdetail>();

        public virtual Branch IdBranch { get; set; } = null!;

        public virtual ProductColor IdProductColor { get; set; } = null!;

    }
}