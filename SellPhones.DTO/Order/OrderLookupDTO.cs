namespace SellPhones.DTO.Order
{
    public class OrderLookupDTO
    {
        public int OrderID { get; set; }
        public string Status { get; set; }
        public double ToltalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public List<ProductDetailLookUp> ProductDetail { get; set; }
        public int BranchProductColorId { get; set; }
    }

    public class ProductDetailLookUp
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string NameColor { get; set; }
        public int BranchProductColorID { get; set; }
    }
}