using Microsoft.AspNetCore.Mvc;

namespace SellPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = new { ok = "oke" };
            return Ok(data);
        }
    }
}