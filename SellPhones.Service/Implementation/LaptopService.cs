using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class LaptopService : BaseService, ILaptopService
    {
        public LaptopService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}