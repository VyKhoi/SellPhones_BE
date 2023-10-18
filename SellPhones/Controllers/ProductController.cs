using Microsoft.AspNetCore.Mvc;
using SellPhones.DTO;
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

        /// <summary>
        /// Danh sách sản phẩm khuyến mãi
        /// </summary>
    
        [HttpPost("Search/promotion")]
        public async Task<ActionResult> SearchPromotionProduct([FromBody] ProductSearchDto dto)
        {
            var rs = await productService.SearchProductPromotionAsync(dto);
            return Ok(rs);
        }
        /// <summary>
        /// Danh sách sản phẩm khuyến mãi
        /// </summary>

        [HttpPost("Search/name")]
        public async Task<ActionResult> SearchProductName([FromBody] ProductSearchDto dto)
        {
            var rs = await productService.SearchProductAsync(dto);
            return Ok(rs);
        }

        [HttpPost("Search/price")]
        public async Task<ActionResult> SearchProductPrice([FromBody] ProductSearchDto dto)
        {
            var rs = await productService.SearchProductFromToPriceAsync(dto);
            return Ok(rs);
        }


        /// <summary>
        /// Chi tiết sản phẩm
        /// </summary>
        /// <param name="Id">ProductId</param>   BranchId
        /// <param name="BranchId">BranchId</param>  
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpPost("Detail")]
        public async Task<ActionResult> DetailProduct([FromBody] RequestDetailProductDTO dto)
        {
            var rs = await productService.SearchDetailProductAsync(dto);
            return Ok(rs);

        }

        /// <summary>
        /// tra cuu san pham
        /// </summary>
        /// <param name="Id">ProductId</param>   BranchId
        /// <param name="BranchId">BranchId</param>  
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpGet("order_lookup/{deliveryPhone}")]
        public async Task<ActionResult> OrderLookUp( string deliveryPhone)
        {
            var rs = await productService.OrderLookUp(deliveryPhone);
            return Ok(rs);

        }


        /// <summary>
        /// danh sách comment
        /// </summary>
        /// <param name="Id">ProductId</param>   BranchId
        /// <param name="BranchId">BranchId</param>  
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpGet("comments/{productId}")]
        public async Task<ActionResult> GetComments(int productId)
        {
            var rs = productService.GetComment(productId);
            return Ok(rs);

        }


        /// <summary>
        /// danh sách comment
        /// </summary>
        /// <param name="Id">ProductId</param>   BranchId
        /// <param name="BranchId">BranchId</param>  
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpPost("comments")]
        public async Task<ActionResult> AddComment([FromBody] CommentPost comment)
        {
            var rs = productService.AddComment(comment);
            return Ok(rs);

        }
    }
}