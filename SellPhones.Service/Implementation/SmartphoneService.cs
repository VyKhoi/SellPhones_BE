using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class SmartphoneService : BaseService, ISmartphoneService
    {
        public SmartphoneService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}