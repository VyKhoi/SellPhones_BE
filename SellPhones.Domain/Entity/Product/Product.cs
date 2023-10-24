using SellPhones.Commons;
using SellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity
{
    [Table("Product")]
    public class Product : IAudit
    {
        public int Id { get; set; }

        public string? Name { get; set; } = null!;

        public string? NameManufactureId { get; set; } = null!;

        public TYPE_PRODUCT? Type { get; set; }

        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }
        public bool? IsActive { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;

        public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

        public virtual Earphone? Earphone { get; set; }

        public virtual ICollection<ImageProduct> ImageProducts { get; set; } = new List<ImageProduct>();

        public virtual Laptop? Laptop { get; set; }

        public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual Smartphone? Smartphone { get; set; }

        public virtual Manufacture NameManufacture { get; set; } = null!;
    }
}