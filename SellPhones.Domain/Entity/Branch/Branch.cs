
using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{ 

    public class Branch: IAudit
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateTime EstablishmentDate { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual ICollection<BranchProductColor> BranchProductColors { get; }
  
     
    }
}
