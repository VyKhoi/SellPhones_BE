using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}