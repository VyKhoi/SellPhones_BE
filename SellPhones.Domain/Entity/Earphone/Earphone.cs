using SellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity
{
    [Table("Earphone")]
    public class Earphone : IAudit
    {
        public int Id { get; set; }

        public string ConnectionType { get; set; } = null!;

        public string Design { get; set; } = null!;

        public string FrequencyResponse { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}