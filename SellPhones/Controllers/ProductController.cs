using Microsoft.AspNetCore.Mvc;
using SellPhones.DTO.Product;

namespace SellPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class ProductController : BaseController
    {
        [HttpPost("Search")]
        public ActionResult SearchProduct([FromBody] ProductSearchDto dto)
        {
            return Ok();
        }
    }
}