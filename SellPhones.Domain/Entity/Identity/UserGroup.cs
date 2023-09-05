using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity.Identity
{
    [Table("UserGroups")]
    public class UserGroup
    {
        //[Key]
        [Column(Order = 1)]
        public Guid GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group? Group { get; set; }

        //[Key]
        [Column(Order = 2)]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}