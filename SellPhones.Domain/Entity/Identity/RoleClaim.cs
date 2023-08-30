using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CellPhones.Domain.Entity.Identity

{
    [Table("RoleClaims")]
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
    }
}
