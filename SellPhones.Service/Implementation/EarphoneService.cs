using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class EarphoneService : BaseService, IEarphoneService
    {
        public EarphoneService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}