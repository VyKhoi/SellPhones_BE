using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity.Identity
{
    [Table("GroupRoles")]
    public class GroupRole
    {
        //[Key]
        [Column(Order = 1)]
        public Guid GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group? Group { get; set; }

        //[Key]
        [Column(Order = 2)]
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
    }
}