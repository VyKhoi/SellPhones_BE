using CellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity
{
    [Table("Smartphone")]
    public class Smartphone : IAudit
    {
        public int Id { get; set; }

        public string OperatorSystem { get; set; } = null!;

        public string Cpu { get; set; } = null!;

        public string Ram { get; set; } = null!;

        public string Rom { get; set; } = null!;

        public string Battery { get; set; } = null!;

        public string Others { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}