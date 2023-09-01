using CellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity
{
    [Table("ImageProduct")]
    public class ImageProduct : IAudit
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string LinkImg { get; set; } = null!;

        public int ProductId { get; set; }

        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}