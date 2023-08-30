using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity.Identity
{
    [Table("UserLogins")]
    public class UserLogin : IdentityUserLogin<Guid>
    {
    }
}
