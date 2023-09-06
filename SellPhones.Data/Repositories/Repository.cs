using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using SellPhones.Data.Interfaces;
using SellPhones.Domain.Entity.Identity;
using System.Linq.Expressions;
using System.Reflection;

namespace SellPhones.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void ChangeTable(string table)
        {
            if (_dbContext.Model.FindEntityType(typeof(TEntity)) is IConventionEntityType relational)
            {
                relational.SetTableName(table);
            }
        }

        public virtual IEnumerable<TEntity> GetByIds(IEnumerable<object> ids, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(i => ids.Contains(i));
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<TEntity> SqlString(string strSql)
        {
            IQueryable<TEntity> query = _dbSet;
            var conn = _dbContext.Database.GetDbConnection();
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = strSql;
            var reader = command.ExecuteReader();
            Guid id = Guid.NewGuid();
            string name = string.Empty;
            while (reader.Read())
            {
                id = reader.GetGuid(0);
                name = reader.GetString(1);
                query.Select(x => new { id });
            }
            return query;
        }

        public async Task<TEntity> GetByIdAsync(object id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(i => id.Equals(i));
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = EntityFrameworkQueryableExtensions.AsNoTracking(query);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>>? predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                         bool disableTracking = true,
                                         bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = EntityFrameworkQueryableExtensions.AsNoTracking(query);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy is not null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = EntityFrameworkQueryableExtensions.AsNoTracking(query);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(orderBy(query));
            }
            else
            {
                return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query);
            }
        }

        public virtual TResult FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>>? selector,
                                                  Expression<Func<TEntity, bool>>? predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                  bool disableTracking = true,
                                                  bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = EntityFrameworkQueryableExtensions.AsNoTracking(query);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).FirstOrDefault();
            }
            else
            {
                return query.Select(selector).FirstOrDefault();
            }
        }

        public virtual async Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>>? selector,
                                                  Expression<Func<TEntity, bool>>? predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                  bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = EntityFrameworkQueryableExtensions.AsNoTracking(query);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy is not null && selector is not null)
            {
                return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(orderBy(query).Select(selector));
            }
            else
            {
                return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query.Select(selector));
            }
        }

        public virtual IQueryable<TEntity> FromSql(string sql, params object[] parameters) => _dbSet.FromSqlRaw(sql, parameters);

        public virtual TEntity Find(params object[] keyValues) => _dbSet.Find(keyValues) ?? null;

        public virtual ValueTask<TEntity> FindAsync(params object[] keyValues) => _dbSet.FindAsync(keyValues);

        public virtual ValueTask<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken) => _dbSet.FindAsync(keyValues, cancellationToken);

        public virtual int Count(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet.Count();
            }
            else
            {
                return _dbSet.Count(predicate);
            }
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return await EntityFrameworkQueryableExtensions.CountAsync(_dbSet);
            }
            else
            {
                return await EntityFrameworkQueryableExtensions.CountAsync(_dbSet, predicate);
            }
        }

        public virtual long LongCount(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet.LongCount();
            }
            else
            {
                return _dbSet.LongCount(predicate);
            }
        }

        public virtual async Task<long> LongCountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return await EntityFrameworkQueryableExtensions.LongCountAsync(_dbSet);
            }
            else
            {
                return await EntityFrameworkQueryableExtensions.LongCountAsync(_dbSet, predicate);
            }
        }

        public virtual T Max<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null)
        {
            if (predicate == null)
                return _dbSet.Max(selector);
            else
                return _dbSet.Where(predicate).Max(selector);
        }

        public virtual async Task<T> MaxAsync<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null)
        {
            if (predicate == null)
                return await EntityFrameworkQueryableExtensions.MaxAsync(_dbSet, selector);
            else
                return await EntityFrameworkQueryableExtensions.MaxAsync(_dbSet.Where(predicate), selector);
        }

        public virtual T Min<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null)
        {
            if (predicate == null)
                return _dbSet.Min(selector);
            else
                return _dbSet.Where(predicate).Min(selector);
        }

        public virtual async Task<T> MinAsync<T>(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, T>>? selector = null)
        {
            if (predicate == null)
                return await EntityFrameworkQueryableExtensions.MinAsync(_dbSet, selector);
            else
                return await EntityFrameworkQueryableExtensions.MinAsync(_dbSet.Where(predicate), selector);
        }

        public virtual decimal Average(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null)
        {
            if (predicate == null)
                return _dbSet.Average(selector);
            else
                return _dbSet.Where(predicate).Average(selector);
        }

        public virtual async Task<decimal> AverageAsync(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null)
        {
            if (predicate == null)
                return await EntityFrameworkQueryableExtensions.AverageAsync(_dbSet, selector);
            else
                return await EntityFrameworkQueryableExtensions.AverageAsync(_dbSet.Where(predicate), selector);
        }

        public virtual decimal Sum(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null)
        {
            if (predicate == null)
                return _dbSet.Sum(selector);
            else
                return _dbSet.Where(predicate).Sum(selector);
        }

        public virtual async Task<decimal> SumAsync(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, decimal>>? selector = null)
        {
            if (predicate == null)
                return await EntityFrameworkQueryableExtensions.SumAsync(_dbSet, selector);
            else
                return await EntityFrameworkQueryableExtensions.SumAsync(_dbSet.Where(predicate), selector);
        }

        public bool Exists(Expression<Func<TEntity, bool>>? selector = null)
        {
            if (selector == null)
            {
                return _dbSet.Any();
            }
            else
            {
                return _dbSet.Any(selector);
            }
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? selector = null)
        {
            if (selector == null)
            {
                return await EntityFrameworkQueryableExtensions.AnyAsync(_dbSet);
            }
            else
            {
                return await EntityFrameworkQueryableExtensions.AnyAsync(_dbSet, selector);
            }
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public virtual void Add(params TEntity[] entities) => _dbSet.AddRange(entities);

        public virtual void Add(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        public virtual ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbSet.AddAsync(entity, cancellationToken);
        }

        public virtual Task AddAsync(params TEntity[] entities) => _dbSet.AddRangeAsync(entities);

        public virtual Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken)) => _dbSet.AddRangeAsync(entities, cancellationToken);

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Update(params TEntity[] entities) => _dbSet.UpdateRange(entities);

        public virtual void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

        public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);

        public virtual void Delete(object id)
        {
            // using a stub entity to mark for deletion
            var typeInfo = typeof(TEntity).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo)!.FindPrimaryKey()!.Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key!.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<TEntity>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                {
                    Delete(entity);
                }
            }
        }

        public virtual void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);

        public virtual void Delete(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await EntityFrameworkQueryableExtensions.ToListAsync(_dbSet);
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = EntityFrameworkQueryableExtensions.AsNoTracking(query);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await EntityFrameworkQueryableExtensions.ToListAsync(orderBy(query));
            }
            else
            {
                return await EntityFrameworkQueryableExtensions.ToListAsync(query);
            }
        }

        public void ChangeEntityState(TEntity entity, EntityState state)
        {
            _dbContext.Entry(entity).State = state;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>,
                IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await Task.Run(() => orderBy(query).AsEnumerable());
            return await Task.Run(() => query.AsEnumerable());
        }

        public void DeleteGroupRoleByGroupId(Guid Id)
        {
            this._dbContext.Set<GroupRole>().Where(x => x.GroupId.Equals(Id))
                .ToList()
                .ForEach(x =>
                {
                    this._dbContext.Remove(x);
                });
        }

        public void InsertGroupRole(GroupRole model)
        {
            this._dbContext.Set<GroupRole>().Add(model);
        }

        public void InsertUserRole(UserRole model)
        {
            this._dbContext.Set<UserRole>().Add(model);
        }

        public void DeleteUserRoleByGroupId(Guid Id)
        {
            this._dbContext.Set<UserRole>().Where(x => x.UserId.Equals(Id))
                .ToList()
                .ForEach(x =>
                {
                    this._dbContext.Remove(x);
                });
        }
    }
}