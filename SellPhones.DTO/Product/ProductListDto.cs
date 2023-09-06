using SellPhones.Commons;

namespace SellPhones.DTO.Product
{
    public class ProductListDto
    {
        public int Id { get; set; } // Id product
        public string Name { get; set; } // Name product
        public string ManufactureName { get; set; }

        public TYPE_PRODUCT Type { get; set; }
    }
}