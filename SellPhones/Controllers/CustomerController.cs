using Microsoft.AspNetCore.Mvc;
using SellPhones.DTO.Customer;
using SellPhones.Service.Interfaces;

namespace SellPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class CustomerController : BaseController
    {
        private IAccountService accountService;

        public CustomerController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Danh sách khach hang
        /// </summary>
        [HttpPost("Search/name")]
        public async Task<ActionResult> GetAllCustomer([FromBody] CustomerFillterDTO dto)
        {
            var rs = await accountService.GetAllCustomer(dto);
            return Ok(rs);
        }
    }
}