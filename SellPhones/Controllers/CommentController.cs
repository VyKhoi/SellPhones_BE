using Microsoft.AspNetCore.Mvc;
using SellPhones.DTO.Comment;
using SellPhones.Service.Interfaces;

namespace SellPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class CommentController : BaseController
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            this._commentService = commentService;
        }

        /// <summary>
        /// get all comment of a product
        /// </summary>
        [HttpGet("{productId}")]
        public async Task<ActionResult> GellAll(int productId)
        {
            var rs = await _commentService.GellAllAsync(productId);
            return Ok(rs);
        }

        /// <summary>
        /// add a comment for a product
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CommentDTO comment)
        {
            var rs = await _commentService.AddAsync(comment);
            return Ok(rs);
        }

        /// <summary>
        /// delete a comment
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var rs = await _commentService.DeleteAsync(id);
            return Ok(rs);
        }
    }
}