using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class BranchPromotionProductService : BaseService, IBranchPromotionProductService
    {
        public BranchPromotionProductService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}