using CellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity
{
    [Table("Earphone")]
    public class Earphone : IAudit
    {
        public int ProductPtrId { get; set; }

        public string ConnectionType { get; set; } = null!;

        public string Design { get; set; } = null!;

        public string FrequencyResponse { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual Product ProductPtr { get; set; } = null!;
    }
}