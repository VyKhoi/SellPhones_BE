using SellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity
{
    [Table("Laptop")]
    public class Laptop : IAudit
    {
        public int Id { get; set; }

        public string Cpu { get; set; } = null!;

        public string Ram { get; set; } = null!;

        public string Rom { get; set; } = null!;

        public string GraphicCard { get; set; } = null!;

        public string Battery { get; set; } = null!;

        public string OperatorSystem { get; set; } = null!;

        public string Others { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}