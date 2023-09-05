using BestEnglish.Services.Extensions.Logger;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SellPhones.Commons;
using SellPhones.Data.Interfaces;
using SellPhones.Domain.Entity.Identity;
using SellPhones.Service.Interfaces;

namespace SellPhones.Service.Implementation
{
    public abstract class BaseService : DisposableObject, IBaseService
    {
        protected UserManager<User>? _userManager;
        protected SignInManager<User>? _signInManager;
        protected ILoggerManager? _logger;
        protected IConfiguration? _configuration;
        protected IUnitOfWork UnitOfWork { get; set; }

        protected BaseService(IUnitOfWork unitOfWork, ILoggerManager? logger, IConfiguration? configuration)
        {
            this.UnitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
        }

        protected BaseService(IUnitOfWork unitOfWork, ILoggerManager? logger)
        {
            UnitOfWork = unitOfWork;
            this._logger = logger;
        }

        protected BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        protected BaseService(IUnitOfWork unitOfWork, IConfiguration? configuration)
        {
            this.UnitOfWork = unitOfWork;
            this._configuration = configuration;
        }

        #region Dispose

        private bool _disposed;

        protected override void Dispose(bool isDisposing)
        {
            if (!this._disposed)
            {
                if (isDisposing)
                {
                    UnitOfWork = null;
                }
                _disposed = true;
            }
        }

        #endregion Dispose
    }
}