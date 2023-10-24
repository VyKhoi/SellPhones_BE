using Microsoft.AspNetCore.Mvc;
using SellPhones.DTO;
using SellPhones.DTO.Comment;
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
        public async Task<ActionResult> OrderLookUp(string deliveryPhone)
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

        /// <summary>
        /// tra cứu đơn hàng
        /// </summary>
        /// <param name="Id">ProductId</param>   BranchId
        /// <param name="BranchId">BranchId</param>
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpGet("home/order_lookup/{deliveryPhone}")]
        public async Task<ActionResult> AddComment(string deliveryPhone)
        {
            var rs = await productService.OrderLookUp(deliveryPhone);
            return Ok(rs);
        }

        /// <summary>
        /// xóa comment của san pham
        /// </summary>
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpDelete("delete/comment/{id}")]
        public async Task<ActionResult> AddComment(int id)
        {
            var rs = await productService.DeleteCommentOfProduct(id);
            return Ok(rs);
        }

        /// <summary>
        /// reply comment cua san pham
        /// </summary>
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpPost("comment")]
        public async Task<ActionResult> ReplyComment([FromBody] CommentPostDTO comment)
        {
            var rs = await productService.ReplyComment(comment);
            return Ok(rs);
        }

       
        /// <summary>
        /// get all thong tin co ban product
        /// </summary>
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpPost("products")]
        public async Task<ActionResult> GetAllProduct([FromBody] ProductSearchDto dto)
        {
            var rs = await productService.GetAllProduct(dto);
            return Ok(rs);
        }
        /// <summary>
        /// Them product
        /// </summary>
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpPost()]
        public async Task<ActionResult> AddProduct([FromBody] ProductListDto dto)
        {
            var rs = productService.AddProduct(dto);
            return Ok(rs);
        }


        /// <summary>
        /// lấy thông tin chi tiết căn bản
        /// </summary>
        /// <returns>Chi tiết sản phẩm</returns>
        [HttpGet("getInforProduct/{id}")]
        public async Task<ActionResult> GetDetailBasicProduct(int id)
        {
            var rs = productService.GetDetailBasicProduct(id);
            return Ok(rs);
        }
    }
}