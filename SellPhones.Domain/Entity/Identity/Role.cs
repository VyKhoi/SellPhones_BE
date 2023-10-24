using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using static SellPhones.Commons.RoleName;

namespace SellPhones.Domain.Entity.Identity

{
    [Table("Roles")]
    public class Role : IdentityRole<Guid>, IEntity<Guid>
    {
        public Role()
        {
            GroupRoles = new HashSet<GroupRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public virtual ICollection<GroupRole> GroupRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public RoleBlock RoleBlock { get; set; }
    }
}