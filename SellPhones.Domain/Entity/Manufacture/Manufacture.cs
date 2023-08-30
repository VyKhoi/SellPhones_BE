using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public  class Manufacture :IAudit
    {
        public string Names { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual ICollection<Product> Products { get; } = new List<Product>();
    }
}
