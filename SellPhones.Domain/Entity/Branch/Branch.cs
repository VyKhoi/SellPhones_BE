using CellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity
{
    [Table("Branch")]
    public class Branch : IAudit
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public DateTime EstablishmentDate { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual ICollection<BranchProductColor> BranchProductColors { get; }
    }
}