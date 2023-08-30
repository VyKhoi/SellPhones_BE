using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public  class Imageproduct :IAudit
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string LinkImg { get; set; } = null!;

        public int ProductId { get; set; }

        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
