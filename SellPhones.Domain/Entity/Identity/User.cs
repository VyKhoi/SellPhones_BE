using Microsoft.AspNetCore.Identity;

namespace SellPhones.Domain.Entity.Identity
{
    public class User : IdentityUser<Guid>, IAudit
    {
        public string? Code { get; set; }

        public string? Name { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public short? Gender { get; set; }

        public string? Hometown { get; set; } = null!;

        public string? UserName { get; set; } = null!;

        public string? PassWord { get; set; }

        public DateTime? BirthDay { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public string? PhoneNumber { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }

        public DateTime? ChangedTimestamp { get; set; }

        public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

        public virtual ICollection<Order> Orders { get; } = new List<Order>();
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}