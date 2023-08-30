using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public class Orderdetail :IAudit
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int BrandProductColorId { get; set; }

        public int OderId { get; set; }

        public decimal UnitPrice { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual BranchProductColor BrandProductColor { get; set; } = null!;

        public virtual Order Oder { get; set; } = null!;
    }
}