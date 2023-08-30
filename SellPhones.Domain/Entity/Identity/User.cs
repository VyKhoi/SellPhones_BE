using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPhones.Domain.Entity.Identity
{
    public class User : IdentityUser<Guid>,IAudit
    {
        public string? Code { get; set; }

        public string? Name { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public short? Gender { get; set; }

        public string? Hometown { get; set; } = null!;

        public string? UserName { get; set; } = null!;

        public string? PassWord { get; set; }

        public DateTime? BirthDay { get; set; }

        public string? PhoneNumber { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }

        public DateTime? ChangedTimestamp { get; set; }

        public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

        public virtual ICollection<Order> Orders { get; } = new List<Order>();

      
    
    }
}
