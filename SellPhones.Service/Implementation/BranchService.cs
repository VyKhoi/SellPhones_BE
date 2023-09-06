using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class BranchService : BaseService, IBranchService
    {
        public BranchService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}