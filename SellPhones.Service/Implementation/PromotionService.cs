using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class PromotionService : BaseService, IPromotionService
    {

        public PromotionService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}