using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public class Promotion : IAudit
    {
        public int Id { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public short Active { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual ICollection<BranchPromotionProduct> BranchPromotionProducts { get; } = new List<BranchPromotionProduct>();
    }
}
