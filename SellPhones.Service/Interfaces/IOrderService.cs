using SellPhones.DTO.Commons;
using SellPhones.DTO.Order;

namespace SellPhones.Service.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseData> AddOrderAsync(OrderRequestDTO dto);
    }
}