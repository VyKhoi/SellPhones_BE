using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}