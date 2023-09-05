using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity.Identity
{
    [Table("UserVerifications")]
    public class UserVerification
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        public DateTime ExpiredAt { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public DateTime AddedTimesTamp { get; set; } = DateTime.UtcNow;
    }
}