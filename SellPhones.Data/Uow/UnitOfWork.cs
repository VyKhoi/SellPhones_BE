using CellPhones.Domain.Entity;
using CellPhones.Domain.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SellPhones.Data.Interfaces;
using SellPhones.Data.Repositories;

namespace SellPhones.Data.Uow
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork
        where TContext : DbContext, IDisposable
    {
        private Dictionary<Type, object> _repositories;
        private IDbContextTransaction transaction;
        public TContext Context { get; }

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(Context);
                return (IRepository<TEntity>)_repositories[type];
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public DbSet<TEntity> SetEntity<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
        {
            try
            {
                if (ensureAutoHistory)
                {
                    Context.EnsureAutoHistory();
                }

                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        [Obsolete]
        public int ExecuteSqlCommand(string query, params object[] parameters)
        {
            return Context.Database.ExecuteSqlRaw(query, parameters);
        }

        [Obsolete]
        public async Task<int> ExecuteSqlCommandAsync(string query, params object[] parameters)
        {
            return await Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void BeginTransaction()
        {
            transaction = Context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            transaction.Commit();
        }

        public void RollbackTransaction()
        {
            transaction.Rollback();
        }

        //User
        private IRepository<User> userRepository;

        public IRepository<User> UserRepository => userRepository ?? (userRepository = GetRepository<User>());

        //Role
        private IRepository<Role> roleRepository;

        public IRepository<Role> RoleRepository => roleRepository ?? (roleRepository = GetRepository<Role>());

        //Group
        private IRepository<Group> groupRepository;

        public IRepository<Group> GroupRepository => groupRepository ?? (groupRepository = GetRepository<Group>());

        //Role in group
        private IRepository<GroupRole> groupRoleRepository;

        public IRepository<GroupRole> GroupRoleRepository => groupRoleRepository ?? (groupRoleRepository = GetRepository<GroupRole>());

        //User in role
        private IRepository<UserRole> userRoleRepository;

        public IRepository<UserRole> UserRoleRepository => userRoleRepository ?? (userRoleRepository = GetRepository<UserRole>());

        //User in group
        private IRepository<UserGroup> userGroupRepository;

        public IRepository<UserGroup> UserGroupRepository => userGroupRepository ?? (userGroupRepository = GetRepository<UserGroup>());

        //UserVerification
        private IRepository<UserVerification> userVerificationRepository;

        public IRepository<UserVerification> UserVerificationRepository => userVerificationRepository ?? (userVerificationRepository = GetRepository<UserVerification>());

        //Branch
        private IRepository<Branch> branchRepository;

        public IRepository<Branch> BranchRepository => branchRepository ?? (branchRepository = GetRepository<Branch>());

        //BranchProductColor
        private IRepository<BranchProductColor> branchProductColorRepository;

        public IRepository<BranchProductColor> BranchProductColorRepository => branchProductColorRepository ?? (branchProductColorRepository = GetRepository<BranchProductColor>());

        //Unit
        private IRepository<BranchPromotionProduct> branchPromotionProductRepository;

        public IRepository<BranchPromotionProduct> BranchPromotionProductRepository => branchPromotionProductRepository ?? (branchPromotionProductRepository = GetRepository<BranchPromotionProduct>());

        //Color
        private IRepository<Color> colorRepository;

        public IRepository<Color> ColorRepository => colorRepository ?? (colorRepository = GetRepository<Color>());

        //Comment
        private IRepository<Comment> commentRepository;

        public IRepository<Comment> CommentRepository => commentRepository ?? (commentRepository = GetRepository<Comment>());

        //Vocabulary
        private IRepository<Earphone> earphoneRepository;

        public IRepository<Earphone> EarphoneRepository => earphoneRepository ?? (earphoneRepository = GetRepository<Earphone>());

        //ImageProduct
        private IRepository<ImageProduct> imageProductRepository;

        public IRepository<ImageProduct> ImageProductRepository => imageProductRepository ?? (imageProductRepository = GetRepository<ImageProduct>());

        //Laptop
        private IRepository<Laptop> laptopRepository;

        public IRepository<Laptop> LaptopRepository => laptopRepository ?? (laptopRepository = GetRepository<Laptop>());

        //Manufacture
        private IRepository<Manufacture> manufactureRepository;

        public IRepository<Manufacture> ManufactureRepository => manufactureRepository ?? (manufactureRepository = GetRepository<Manufacture>());

        //Order
        private IRepository<Order> orderRepository;

        public IRepository<Order> OrderRepository => orderRepository ?? (orderRepository = GetRepository<Order>());

        //OrderDetail
        private IRepository<OrderDetail> orderDetailRepository;

        public IRepository<OrderDetail> OrderDetailRepository => orderDetailRepository ?? (orderDetailRepository = GetRepository<OrderDetail>());

        //Product
        private IRepository<Product> productRepository;

        public IRepository<Product> ProductRepository => productRepository ?? (productRepository = GetRepository<Product>());

        //ProductColor
        private IRepository<ProductColor> productColorRepository;

        public IRepository<ProductColor> ProductColorRepository => productColorRepository ?? (productColorRepository = GetRepository<ProductColor>());

        //Promotion
        private IRepository<Promotion> promotionRepository;

        public IRepository<Promotion> PromotionRepository => promotionRepository ?? (promotionRepository = GetRepository<Promotion>());

        //Review
        private IRepository<Review> peviewRepository;

        public IRepository<Review> ReviewRepository => peviewRepository ?? (peviewRepository = GetRepository<Review>());

        //Smartphone
        private IRepository<Smartphone> smartphoneRepository;

        public IRepository<Smartphone> SmartphoneRepository => smartphoneRepository ?? (smartphoneRepository = GetRepository<Smartphone>());
    }
}