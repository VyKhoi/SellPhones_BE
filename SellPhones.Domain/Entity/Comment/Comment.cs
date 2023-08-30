using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public class Comment : IAudit
    {
        public int Id { get; set; }

        public string ContentComment { get; set; } = null!;

        public int ProductId { get; set; }

        public Guid? UserId { get; set; }

        public int? ReplyId { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }


        public virtual Product IdProduct { get; set; } = null!;

        public virtual Comment? IdReplyNavigation { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Comment> InverseIdReplyNavigation { get; } = new List<Comment>();
        }
}
