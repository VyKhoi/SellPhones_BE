using Microsoft.AspNetCore.Mvc;
using SellPhones.DTO.Order;
using SellPhones.Service.Implementation;
using SellPhones.Service.Interfaces;

namespace SellPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class OrderController : BaseController
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {

            this._orderService = orderService;
        }

        [HttpPost("checkout-succeed")]
        public async Task<ActionResult> GellAll(OrderRequestDTO dto)
        {
            var rs = await _orderService.AddOrderAsync(dto);
            return Ok(rs);
        }


    }
}
