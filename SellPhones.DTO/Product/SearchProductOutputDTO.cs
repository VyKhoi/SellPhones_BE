using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.DTO.Product
{
    public class SearchProductOutputDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BranchName { get; set; }
        public string? ManufactureName { get; set; }
        public double? CurrentPrice { get; set; }
        public double? Price { get; set; }
        public double? DiscountRate { get; set; }
        public int? ProductColorId { get; set; }
        public string? CurrentColor { get; set; }
        public string? CurrentImage { get; set; }
        public string? ReviewTitle { get; set; }
        public string? Introduce { get; set; }
        public int? Amount { get; set; }
        public int? BranchProductColorId { get; set; }
    }
}
