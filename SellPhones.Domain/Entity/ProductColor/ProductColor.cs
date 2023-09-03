using CellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity
{
    [Table("ProductColor")]
    public class ProductColor : IAudit
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public string NameColorId { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual ICollection<BranchProductColor> BranchProductColors { get; } = new List<BranchProductColor>();

        public virtual Product Product { get; set; } = null!;

        public virtual Color NameColor { get; set; } = null!;
    }
}