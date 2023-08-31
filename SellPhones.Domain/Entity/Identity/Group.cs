using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity.Identity
{
    [Table("Groups")]
    public class Group : IEntity<Guid>
    {
        public Group()
        {
            GroupRoles = new HashSet<GroupRole>();
            UserGroups = new HashSet<UserGroup>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public bool IsMobile { get; set; } = true;

        [Required]
        public bool IsWeb { get; set; } = true;

        [StringLength(500, ErrorMessage = "Name cannot be longer than 500 characters.")]
        public string? Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string? Description { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool IsActivated { get; set; } = true;
        public bool IsShowed { get; set; }
        public virtual ICollection<GroupRole> GroupRoles { set; get; }
        public virtual ICollection<UserGroup> UserGroups { set; get; }
    }
}