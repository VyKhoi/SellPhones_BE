using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

        // create
    }
}