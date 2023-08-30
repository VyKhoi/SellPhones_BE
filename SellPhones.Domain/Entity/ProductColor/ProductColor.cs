using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public class ProductColor : IAudit
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int IdProductId { get; set; }

        public string NameColorId { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }


        public virtual ICollection<BranchProductColor> BranchProductColors { get; } = new List<BranchProductColor>();

        public virtual Product IdProduct { get; set; } = null!;

        public virtual Color NameColor { get; set; } = null!;
    }
}
