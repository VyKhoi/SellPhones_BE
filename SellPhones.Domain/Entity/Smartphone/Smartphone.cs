using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public class Smartphone :IAudit
    {
        public int ProductPtrId { get; set; }

        public string OperatorSystem { get; set; } = null!;

        public string Cpu { get; set; } = null!;

        public string Ram { get; set; } = null!;

        public string Rom { get; set; } = null!;

        public string Battery { get; set; } = null!;

        public string Others { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual Product ProductPtr { get; set; } = null!;
    }
}
