using Microsoft.EntityFrameworkCore;
using SellPhones.Domain.Entity;
using SellPhones.Domain.Entity.Identity;

namespace SellPhones.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the specified repository for the <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        DbSet<TEntity> SetEntity<TEntity>() where TEntity : class;

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync(bool ensureAutoHistory = false);

        int ExecuteSqlCommand(string query, params object[] parameters);

        Task<int> ExecuteSqlCommandAsync(string query, params object[] parameters);

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        //User
        IRepository<User> UserRepository { get; }

        IRepository<Role> RoleRepository { get; }
        IRepository<Group> GroupRepository { get; }
        IRepository<GroupRole> GroupRoleRepository { get; }
        IRepository<UserGroup> UserGroupRepository { get; }
        IRepository<UserRole> UserRoleRepository { get; }

        //Branch
        IRepository<Branch> BranchRepository { get; }

        IRepository<BranchProductColor> BranchProductColorRepository { get; }
        IRepository<BranchPromotionProduct> BranchPromotionProductRepository { get; }

        //Color
        IRepository<Color> ColorRepository { get; }

        //comment
        IRepository<Comment> CommentRepository { get; }

        //Earphone
        IRepository<Earphone> EarphoneRepository { get; }

        //Imageproduct
        IRepository<ImageProduct> ImageProductRepository { get; }

        //Laptop
        IRepository<Laptop> LaptopRepository { get; }

        //Manufacture
        IRepository<Manufacture> ManufactureRepository { get; }

        //Learner
        IRepository<Order> OrderRepository { get; }

        //OrderDetail
        IRepository<OrderDetail> OrderDetailRepository { get; }

        //Product
        IRepository<Product> ProductRepository { get; }

        IRepository<ProductColor> ProductColorRepository { get; }

        //Promotion
        IRepository<Promotion> PromotionRepository { get; }

        IRepository<UserVerification> UserVerificationRepository { get; }

        //Review
        IRepository<Review> ReviewRepository { get; }

        //Smartphone
        IRepository<Smartphone> SmartphoneRepository { get; }
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        /// <summary>
        /// Gets the db context.
        /// </summary>
        TContext Context { get; }
    }
}