using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}