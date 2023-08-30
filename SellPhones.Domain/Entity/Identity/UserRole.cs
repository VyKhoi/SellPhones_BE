using CellPhones.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity.Identity
{
    [Table("UserRoles")]
    public class UserRole : IdentityUserRole<Guid>
    {
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
