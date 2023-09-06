using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity.Identity
{
    [Table("UserClaims")]
    public class UserClaim : IdentityUserClaim<Guid>
    {
    }
}