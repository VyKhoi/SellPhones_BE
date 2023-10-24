using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SellPhones.Domain.Entity.Identity
{
    public enum TYPE_LOGIN
    {
        [Display(Name = "1")]
        System = 1,

        [Display(Name = "2")]
        Google = 2,

        [Display(Name = "3")]
        Facebook = 3,

        [Display(Name = "4")]
        Apple = 4,
    }

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

        public Guid? GroupId { get; set; }

        public string? PhoneNumber { get; set; } = null!;
        public DateTime? AddedTimestamp { get; set; }

        public DateTime? ChangedTimestamp { get; set; }
        public string? FirebaseTokenWeb { get; set; }
        public string? SocialId { get; set; } = null;

        public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

        public virtual ICollection<Order> Orders { get; } = new List<Order>();
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}