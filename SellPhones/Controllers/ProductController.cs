using Microsoft.AspNetCore.Mvc;
using SellPhones.DTO.Product;
using SellPhones.Service.Interfaces;

namespace SellPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class ProductController : BaseController
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Danh sách sản phẩm
        /// </summary>
        /// <returns>Danh sách sản phẩm</returns>
        [HttpPost("Search")]
        public async Task<ActionResult> SearchProduct([FromBody] ProductSearchDto dto)
        {
            var rs = await productService.SearchAsync(dto);
            return Ok(rs);
        }
    }
}