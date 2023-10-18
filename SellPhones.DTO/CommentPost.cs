using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.DTO
{
    public class CommentPost
    {

        public string? ContentComment { get; set; } = null!;

        public int? IdProductId { get; set; }

        public Guid? IdUserId { get; set; }

        public int? IdReply { get; set; }
    }
}
