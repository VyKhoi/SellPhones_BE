using Microsoft.AspNetCore.Mvc;
using SellPhones.DTO.Order;
using SellPhones.DTO.Product;
using SellPhones.Service.Interfaces;

namespace SellPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class OrderController : BaseController
    {
        private IOrderService _orderService;
        private IPayment _payment;

        public OrderController(IOrderService orderService, IPayment payment)
        {
            this._orderService = orderService;
            this._payment = payment;
        }

        [HttpPost("checkout-succeed")]
        public async Task<ActionResult> GellAll([FromBody] OrderRequestDTO dto)
        {
            var rs = await _orderService.AddOrderAsync(dto);
            return Ok(rs);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult> PaymentStripe([FromBody] PaymentStripeDTO dto)
        {
            var rs = _payment.PaymentStripeAsync(dto);
            return Ok(rs);
        }
    }
}