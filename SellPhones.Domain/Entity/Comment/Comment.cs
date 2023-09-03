using CellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity
{
    [Table("Comment")]
    public class Comment : IAudit
    {
        public int Id { get; set; }

        public string ContentComment { get; set; } = null!;

        public int ProductId { get; set; }

        public Guid? UserId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int? ReplyId { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual Product Product { get; set; } = null!;

        public virtual Comment? ReplyNavigation { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Comment> InverseIdReplyNavigations { get; } = new List<Comment>();
    }
}