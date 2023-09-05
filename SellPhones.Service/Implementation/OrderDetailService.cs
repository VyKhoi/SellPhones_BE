using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class OrderDetailService : BaseService, IOrderDetailService
    {
        public OrderDetailService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}