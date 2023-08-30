using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public class Product : IAudit
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string NameManufactureId { get; set; } = null!;

        public string? Type { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

        public virtual Earphone? Earphone { get; set; }

        public virtual ICollection<Imageproduct> Imageproducts { get; set; } = new List<Imageproduct>();

        public virtual Laptop? Laptop { get; set; }

        public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual Smartphone? Smartphone { get; set; }

        public virtual Manufacture NameManufacture { get; set; } = null!;
    }
}
