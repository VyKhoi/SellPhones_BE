using SellPhones.Domain.Entity;
using SellPhones.DTO;
using SellPhones.DTO.Commons;
using SellPhones.DTO.Product;

namespace SellPhones.Service.Interfaces
{
    public interface IProductService
    {
        Task<ResponseData> SearchAsync(ProductSearchDto search);

        Task<ResponseData> SearchSmartphoneAsync(ProductSearchDto dto);

        Task<ResponseData> SearchLaptopAsync(ProductSearchDto dto);

        Task<ResponseData> SearchEarphoneAsync(ProductSearchDto dto);

        Task<ResponseData> DetailProductSmartphoneAsync(RequestDetailProductDTO dto);

        Task<ResponseData> DetailProductLaptopAsync(RequestDetailProductDTO dto);

        Task<ResponseData> SearchProductPromotionAsync(ProductSearchDto dto);

        Task<ResponseData> SearchProductAsync(ProductSearchDto dto);
        Task<ResponseData> SearchDetailProductAsync(RequestDetailProductDTO dto);
        Task<ResponseData> SearchProductFromToPriceAsync(ProductSearchDto dto);
        Task<ResponseData> OrderLookUp(string deliveryPhone);
        string GetComment(int productId);
        Comment AddComment(CommentPost comment);



    }
}