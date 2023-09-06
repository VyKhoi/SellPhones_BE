using SellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity
{
    [Table("Order")]
    public class Order : IAudit
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; } = null!;

        public string DeliveryPhone { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string Status { get; set; } = null!;

        public Guid? UserId { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

        public virtual User User { get; set; } = null!;
    }
}