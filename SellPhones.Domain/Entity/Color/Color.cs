using System.ComponentModel.DataAnnotations.Schema;

namespace CellPhones.Domain.Entity
{
    [Table("Color")]
    public class Color
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductColor> ProductColors { get; } = new List<ProductColor>();
    }
}