using System;
using System.Collections.Generic;
using System.Text;

namespace SellPhones.Data.Interfaces
{
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Gets the specified repository for the <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> GetRepository<T>() where T : class;
    }
}
