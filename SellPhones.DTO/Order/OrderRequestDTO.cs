using Newtonsoft.Json;
using SellPhones.DTO.Product;

namespace SellPhones.DTO.Order
{
    public class OrderRequestDTO
    {
        [JsonProperty("amountEachProduct")]
        public Dictionary<int, int>? AmountEachProduct { get; set; }

        public CustomerPaymentStripeDTO? Customer { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<ProductPaymentStripeDTO>? Products { get; set; }
    }
}