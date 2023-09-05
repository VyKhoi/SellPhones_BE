using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class ColorService : BaseService, IColorService
    {
        public ColorService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
    }
}