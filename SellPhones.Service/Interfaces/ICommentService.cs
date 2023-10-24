using SellPhones.DTO.Comment;
using SellPhones.DTO.Commons;

namespace SellPhones.Service.Interfaces
{
    public interface ICommentService
    {
        Task<ResponseData> GellAllAsync(int productId);

        Task<ResponseData> AddAsync(CommentDTO comment);

        Task<ResponseData> DeleteAsync(int id);
    }
}