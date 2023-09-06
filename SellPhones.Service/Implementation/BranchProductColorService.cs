using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class BranchProductColorService : BaseService, IBranchProductColorService
    {
        public BranchProductColorService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}