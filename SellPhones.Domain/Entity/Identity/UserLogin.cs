using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity.Identity
{
    [Table("UserLogins")]
    public class UserLogin : IdentityUserLogin<Guid>
    {
    }
}