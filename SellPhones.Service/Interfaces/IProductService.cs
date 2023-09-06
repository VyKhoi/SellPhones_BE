using SellPhones.DTO.Commons;
using SellPhones.DTO.Product;

namespace SellPhones.Service.Interfaces
{
    public interface IProductService
    {
        Task<ResponseData> SearchAsync(ProductSearchDto search);
        Task<ResponseData> SearchSmartphoneAsync(ProductSearchDto dto);
    }
}