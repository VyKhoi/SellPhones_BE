using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SellPhones.Domain.Entity.Identity;

namespace SellPhones.Security.Identity
{
    public class SecurityDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public SecurityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<UserRole>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            modelBuilder.Entity<Role>(b =>
            {
                b.ToTable("Roles");
            });

            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("Users");
            });

            modelBuilder.Entity<UserGroup>()
                 .ToTable("UserGroups")
                 .HasKey(c => new { c.GroupId, c.UserId });
            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId);
            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.GroupId);

            modelBuilder.Entity<GroupRole>()
                .ToTable("GroupRoles")
                .HasKey(c => new { c.GroupId, c.RoleId });
            modelBuilder.Entity<GroupRole>()
                .HasOne(gr => gr.Group)
                .WithMany(a => a.GroupRoles)
                .HasForeignKey(gr => gr.GroupId);
            modelBuilder.Entity<GroupRole>()
                .HasOne(gr => gr.Role)
                .WithMany(a => a.GroupRoles)
                .HasForeignKey(gr => gr.RoleId);
        }

        public virtual DbSet<Group>? Group { get; set; }
        public virtual DbSet<GroupRole>? GroupRole { get; set; }
        public virtual DbSet<Role>? Role { get; set; }
        public virtual DbSet<RoleClaim>? RoleClaim { get; set; }
        public virtual DbSet<User>? User { get; set; }
        public virtual DbSet<UserClaim>? UserClaim { get; set; }
        public virtual DbSet<UserGroup>? UserGroup { get; set; }
        public virtual DbSet<UserLogin>? UserLogin { get; set; }
        public virtual DbSet<UserRole>? UserRole { get; set; }
        public virtual DbSet<UserToken>? UserToken { get; set; }
        public virtual DbSet<UserVerification>? UserVerification { get; set; }
    }
}