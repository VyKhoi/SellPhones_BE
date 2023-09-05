using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity.Identity

{
    [Table("RoleClaims")]
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
    }
}