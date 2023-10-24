using SellPhones.Commons;

namespace SellPhones.DTO.Product
{
    public class ProductListDto
    {
        public int? Id { get; set; } // Id product
        public string? Name { get; set; } // Name product
        public string? ManufactureName { get; set; }
        public TYPE_PRODUCT? Type { get; set; }
        public string? BranchName { get; set; }

        public double? CurrentPrice { get; set; }
        public double? Price { get; set; }
        public double? DiscountRate { get; set; }
        public int? ProductColorId { get; set; }
        public string? CurrentColor { get; set; }
        public string? CurrentImage { get; set; }
        public string? ReviewTitle { get; set; }
        public string? Introduce { get; set; }
        public string? OperatorSystem { get; set; }
        public string? CPU { get; set; }
        public string? RAM { get; set; }
        public string? ROM { get; set; }
        public string? Battery { get; set; }
        public string? Others { get; set; }
        public string? GraphicCard { get; set; }
        public string? ConnectionType { get; set; }

        public string? Design { get; set; }

        public string? FrequencyResponse { get; set; }
        public int? Amount { get; set; }
        public int? BranchProductColorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


        public List<ImagesProduct> Images { get; set; }
    }

    public class ImagesProduct
    {
        public string NameImage { get; set; }
        public string Images { get; set; }


    }
}