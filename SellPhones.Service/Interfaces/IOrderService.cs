using SellPhones.DTO.Commons;
using SellPhones.DTO.Order;
using SellPhones.DTO.Product;

namespace SellPhones.Service.Interfaces
{
    public interface IOrderService
    {
       Task<ResponseData> AddOrderAsync(OrderRequestDTO dto);
    }
}