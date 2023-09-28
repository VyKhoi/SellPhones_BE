using Microsoft.EntityFrameworkCore;
using SellPhones.Commons;
using SellPhones.Data.Interfaces;
using SellPhones.Domain.Entity;
using SellPhones.DTO.Comment;
using SellPhones.DTO.Commons;
using SellPhones.Service.Interfaces;
using System.Net;

namespace SellPhones.Service.Implementation
{
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

        // gett all comment of product
        public async Task<ResponseData> GellAllAsync(int productId)
        {
            try
            {
                var dataList = new DataList<List<CommentDTO>>();
                var query = UnitOfWork.CommentRepository.GetAll().Where(c => c.ProductId == productId && c.IsDeleted == false && c.IsActive == true)
                    .Include(c => c.InverseIdReplyNavigations)
                    .ThenInclude(r => r.User)
                    .Select(c => new CommentDTO
                    {
                        Id = c.Id,
                        UserName = c.User.UserName,
                        ContentComment = c.ContentComment,
                        UserId = c.User.Id,
                        ProductId = c.ProductId,
                        CommentReply = c.InverseIdReplyNavigations
                          .Select(r => new CommentReplyDTO
                          {
                              Id = r.Id,
                              UserName = r.User.UserName,
                              ContentComment = r.ContentComment,
                              UserId = r.User.Id,
                              ProductId = r.ProductId,// lấy thông tin userName của các comment phản hồi
                          }).ToList()
                    }).ToList();
                // get total record
                dataList.TotalRecord = query != null ? query.Count() : 0;
                dataList.Items = query;
                return new ResponseData(dataList);
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        public async Task<ResponseData> AddAsync(CommentDTO comment)
        {
            try // get all off infor relate of that product ( smartphone )
            {
                System.Diagnostics.Debug.WriteLine("nó có vào hàm post comment" + comment);
                var cm = new Comment()
                {
                    ContentComment = comment.ContentComment,
                    ProductId = comment.ProductId,
                    UserId = comment.UserId,
                    ReplyId = comment.ReplyId
                };

                UnitOfWork.CommentRepository.Add(cm);
                UnitOfWork.SaveChanges();

                return new ResponseData(cm);
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        public async Task<ResponseData> DeleteAsync(int id)
        {
            var comment = await UnitOfWork.CommentRepository.FindAsync(id);
            if (comment == null)
            {
                return new ResponseData(HttpStatusCode.BadGateway, false, ErrorCode.NOT_FOUND);
            }

            comment.IsDeleted = true;
            comment.IsActive = false;
            // Xóa tất cả các comment reply của comment này

            UnitOfWork.CommentRepository.Update(comment);
            await UnitOfWork.SaveChangesAsync();

            return new ResponseData(id);
        }
    }
}