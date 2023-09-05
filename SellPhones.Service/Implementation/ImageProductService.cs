using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class ImageProductService : BaseService, IImageProductService
    {
        public ImageProductService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
    }
}