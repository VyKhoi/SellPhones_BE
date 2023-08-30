using CellPhones.Domain.Entity.Identity;
using System;
using System.Collections.Generic;

namespace CellPhones.Domain.Entity
{
    public  class Order : IAudit
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; } = null!;

        public string DeliveryPhone { get; set; } = null!;

        public string Status { get; set; } = null!;

        public Guid? UserId { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? ChangedTimestamp { get; set; }


        public virtual ICollection<Orderdetail> Orderdetails { get; } = new List<Orderdetail>();

        public virtual User User { get; set; } = null!;
    }
}