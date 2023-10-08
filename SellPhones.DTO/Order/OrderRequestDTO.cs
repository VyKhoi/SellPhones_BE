using Newtonsoft.Json;
using SellPhones.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.DTO.Order
{
    public class OrderRequestDTO
    {
        [JsonProperty("amountEachProduct")]
        public Dictionary<int, int> AmountEachProduct { get; set; }
        public CustomerPaymentStripeDTO Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductPaymentStripeDTO> Products { get; set; }
    }
}
