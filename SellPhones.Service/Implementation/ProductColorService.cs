using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class ProductColorService : BaseService, IProductColorService
    {
        public ProductColorService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}