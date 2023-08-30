namespace CellPhones.Domain.Entity
{
    public class Color
    {
        public string Names { get; set; } = null!;

        public virtual ICollection<ProductColor> ProductColors { get; } = new List<ProductColor>();
    }
}