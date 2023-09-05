using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using SellPhones.Domain.Entity.Identity;
using System.Linq.Expressions;

namespace SellPhones.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void ChangeTable(string table);

        TEntity GetById(object id);

        Task<TEntity> GetByIdAsync(object id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetByIds(IEnumerable<object> ids, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> FromSql(string sql, params object[] parameters);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>>? predicate = null,
                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                  bool disableTracking = true,
                                  bool ignoreQueryFilters = false);

        TResult FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>>? selector,
                                           Expression<Func<TEntity, bool>>? predicate = null,
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                           bool disableTracking = true,
                                           bool ignoreQueryFilters = false);

        Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>>? selector,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false);

        TEntity Find(params object[] keyValues);

        ValueTask<TEntity> FindAsync(params object[] keyValues);

        ValueTask<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                  bool disableTracking = true,
                                                  bool ignoreQueryFilters = false);

        Task<IList<TEntity>> GetAllAsync();

        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                  bool disableTracking = true,
                                                  bool ignoreQueryFilters = false);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
          bool disableTracking = true,
          CancellationToken cancellationToken = default(CancellationToken));

        int Count(Expression<Func<TEntity, bool>>? predicate = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);

        long LongCount(Expression<Func<TEntity, bool>>? predicate = null);

        Task<long> LongCountAsync(Expression<Func<TEntity, bool>>? predicate = null);

        T Max<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null);

        Task<T> MaxAsync<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null);

        T Min<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null);

        Task<T> MinAsync<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null);

        decimal Average(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null);

        Task<decimal> AverageAsync(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null);

        decimal Sum(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null);

        Task<decimal> SumAsync(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null);

        bool Exists(Expression<Func<TEntity, bool>>? selector = null);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? selector = null);

        TEntity Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task AddAsync(params TEntity[] entities);

        Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

        void Update(TEntity entity);

        void Update(params TEntity[] entities);

        void Update(IEnumerable<TEntity> entities);

        void Delete(object id);

        void Delete(TEntity entity);

        void Delete(params TEntity[] entities);

        void Delete(IEnumerable<TEntity> entities);

        void ChangeEntityState(TEntity entity, EntityState state);

        void InsertGroupRole(GroupRole model);

        void DeleteGroupRoleByGroupId(Guid Id);

        void InsertUserRole(UserRole model);

        void DeleteUserRoleByGroupId(Guid Id);

        IQueryable<TEntity> SqlString(string strSql);
    }
}