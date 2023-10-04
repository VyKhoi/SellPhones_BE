using SellPhones.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.DTO.Product
{
    public class DetailProductDTO
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }   
        public string? ManufactureName { get; set; }
        public decimal? Price { get; set; }
        public decimal? CurrentPrice { get; set; }
        public int? ProductColorId { get; set; }
        public string? ColorName { get; set; }
        public string? ImageDefualtLink { get; set; }
        public string? ReviewTitle { get; set;}
        public string? Introduce { get; set;}
        public string? OperatorSystem { get; set; }
        public string? BranchName { get; set; }
        public double? DiscountRate { get; set; }

        public int? BranchProductColorId { get; set; }
        public string? CPU { get; set;}
        public string? RAM { get; set;}
        public string? ROM { get; set;}
        public string? Battery { get; set;}
        public string? Others { get; set; }
        public string? GraphicCard { get; set; } 
        public int? Amount { get; set;}

        public string? NameColorId { get; set; }
        public string? ImageLink { get; set; }

        public List<OptionalProduct>? Options = new List<OptionalProduct>();
        public List<ProductColorDTO>? Color = new List<ProductColorDTO>();

        public List<ImageProductDTO>? Image = new List<ImageProductDTO>();

    }

    public class OptionalProduct // option of product
    {
        public int ProductId { get; set; } // product id

        public string? RAM { get; set; }
        public string? ROM { get; set; }
    }
    public class ImageProductDTO // option of product
    {
        public string? Name { get; set; }
        public string? Link { get; set; }
    }
    //product color
    public class ProductColorDTO
    {
        public int BranchProductColorId { get; set; }
        public string Color { get; set; }

        public decimal? Price { get; set; }

    }
}
