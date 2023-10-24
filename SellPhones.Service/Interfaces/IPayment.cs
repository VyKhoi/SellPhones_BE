using SellPhones.DTO.Commons;
using SellPhones.DTO.Product;

namespace SellPhones.Service.Interfaces
{
    public interface IPayment
    {
        ResponseData PaymentStripeAsync(PaymentStripeDTO dto);
    }
}