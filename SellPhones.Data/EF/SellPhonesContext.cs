﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SellPhones.Domain.Entity;
using SellPhones.Domain.Entity.Identity;

namespace SellPhones.Data.EF
{
    public class SellPhonesContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public SellPhonesContext(DbContextOptions<SellPhonesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users").HasKey(x => x.Id);
            modelBuilder.Entity<Role>().ToTable("Roles").HasKey(x => x.Id);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims").HasKey(x => x.Id);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims").HasKey(x => x.Id);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<UserToken>().ToTable("UserTokens").HasKey(x => x.UserId);

            modelBuilder.Entity<UserGroup>()
                 .ToTable("UserGroups")
                 .HasKey(c => new { c.GroupId, c.UserId });

            modelBuilder.Entity<GroupRole>()
                .ToTable("GroupRoles")
                .HasKey(c => new { c.GroupId, c.RoleId });

            modelBuilder.Entity<UserRole>()
               .ToTable("UserRoles")
               .HasKey(c => new { c.RoleId, c.UserId });

            ///

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_branch_Id");

                entity.ToTable("Branch");

                entity.Property(e => e.Address).HasMaxLength(50);
                entity.Property(e => e.EstablishmentDate).HasColumnType("date");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<BranchProductColor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_branch_product_color_Id");

                entity.ToTable("BranchProductColor");

                entity.Property(e => e.BranchId).HasColumnName("BranchId");
                entity.Property(e => e.ProductColorId).HasColumnName("ProductColorId");

                entity.HasOne(d => d.Branch).WithMany(p => p.BranchProductColors)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("branch_product_color$branch__idBranch_id_edb533ab_fk_cellphone");

                entity.HasOne(d => d.ProductColor).WithMany(p => p.BranchProductColors)
                    .HasForeignKey(d => d.ProductColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("branch_product_color$branch__idProductColor_id_fbdccc0b_fk_cellphone");
            });

            modelBuilder.Entity<BranchPromotionProduct>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_branch_promotion_product_Id");

                entity.ToTable("BranchPromotionProduct");

                entity.Property(e => e.DiscountRate).HasColumnName("DiscountRate");
                entity.Property(e => e.BrandProductColorId).HasColumnName("BrandProductColorId");
                entity.Property(e => e.PromotionId).HasColumnName("PromotionId");

                entity.HasOne(d => d.BrandProductColor).WithMany(p => p.BranchPromotionProducts)
                    .HasForeignKey(d => d.BrandProductColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("branch_promotion_product$branch__idBrandProductColor__95f82815_fk_cellphone");

                entity.HasOne(d => d.Promotion).WithMany(p => p.BranchPromotionProducts)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("branch_promotion_product$branch__idPromotion_id_3456dae1_fk_cellphone");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.Name).HasName("PK_color_names");

                entity.ToTable("Color");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_comment_Id");

                entity.ToTable("Comment");

                entity.Property(e => e.ContentComment)
                    .HasMaxLength(100)
                    .HasColumnName("ContentComment");
                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.ReplyId).HasColumnName("ReplyId");
                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment$comment_idProduct_id_886d85ab_fk_cellphone");

                entity.HasOne(d => d.ReplyNavigation).WithMany(p => p.InverseIdReplyNavigations)
                    .HasForeignKey(d => d.ReplyId)
                    .HasConstraintName("FK_comment_comment");

                entity.HasOne(d => d.User).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment$comment_idUser_id_d2fff2a5_fk_user_Id");
            });

            modelBuilder.Entity<Earphone>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_earphone_product_ptr_id");

                entity.ToTable("Earphone");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.ConnectionType)
                    .HasMaxLength(50)
                    .HasColumnName("ConnectionType");
                entity.Property(e => e.Design).HasMaxLength(50);
                entity.Property(e => e.FrequencyResponse)
                    .HasMaxLength(50)
                    .HasColumnName("FrequencyResponse");

                entity.HasOne(d => d.Product).WithOne(p => p.Earphone)
                    .HasForeignKey<Earphone>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("earphone$earphon_product_ptr_id_af17d76e_fk_cellphone");
            });

            modelBuilder.Entity<ImageProduct>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_imageproduct_Id");

                entity.ToTable("ImageProduct");

                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.LinkImg)
                    .HasMaxLength(255)
                    .HasColumnName("LinkImg");
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Product).WithMany(p => p.ImageProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("imageproduct$imagepr_idProduct_id_4de16385_fk_cellphone");
            });

            modelBuilder.Entity<Laptop>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_laptop_product_ptr_id");

                entity.ToTable("Laptop");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.Battery).HasMaxLength(30);
                entity.Property(e => e.Cpu)
                    .HasMaxLength(50)
                    .HasColumnName("CPU");
                entity.Property(e => e.GraphicCard)
                    .HasMaxLength(50)
                    .HasColumnName("Graphic_Card");
                entity.Property(e => e.OperatorSystem)
                    .HasMaxLength(50)
                    .HasColumnName("OperatorSystem");
                entity.Property(e => e.Others).HasMaxLength(50);
                entity.Property(e => e.Ram)
                    .HasMaxLength(50)
                    .HasColumnName("RAM");
                entity.Property(e => e.Rom)
                    .HasMaxLength(50)
                    .HasColumnName("ROM");

                entity.HasOne(d => d.Product).WithOne(p => p.Laptop)
                    .HasForeignKey<Laptop>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("laptop$laptop_product_ptr_id_137bfb4d_fk_cellphone");
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.HasKey(e => e.Name).HasName("PK_manufacture_names");

                entity.ToTable("Manufacture");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_order_Id");

                entity.ToTable("Order");

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(50)
                    .HasColumnName("DeliveryAddress");
                entity.Property(e => e.DeliveryPhone)
                    .HasMaxLength(50)
                    .HasColumnName("DeliveryPhone");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.OrderDate)
                    .HasPrecision(6)
                    .HasColumnName("OrderDate");
                entity.Property(e => e.Status).HasMaxLength(30);

                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order$order_idUser_id_bb73099a_fk_user_Id");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_orderdetail_Id");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.BrandProductColorId).HasColumnName("BrandProductColorId");
                entity.Property(e => e.OderId).HasColumnName("OderId");
                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("UnitPrice");

                entity.HasOne(d => d.BrandProductColor).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.BrandProductColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderdetail$orderde_idBrandProductColor__980f79ef_fk_cellphone");

                entity.HasOne(d => d.Oder).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderdetail$orderde_idOder_id_6730d0c3_fk_cellphone");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_product_Id");

                entity.ToTable("Product");

                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.NameManufactureId)
                    .HasMaxLength(100)
                    .HasColumnName("NameManufactureId");

                entity.HasOne(d => d.NameManufacture).WithMany(p => p.Products)
                    .HasForeignKey(d => d.NameManufactureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product$product_nameManufacture_id_473540a7_fk_cellphone");
            });

            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_product_color_Id");

                entity.ToTable("ProductColor");

                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.NameColorId)
                    .HasMaxLength(50)
                    .HasColumnName("NameColorId");
                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_color$product_idProduct_id_057d2aaf_fk_cellphone");

                entity.HasOne(d => d.NameColor).WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.NameColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_color$product_nameColor_id_0ea8764a_fk_cellphone");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_promotion_Id");

                entity.ToTable("Promotion");

                entity.Property(e => e.TimeEnd)
                    .HasPrecision(6)
                    .HasColumnName("TimeEnd");
                entity.Property(e => e.TimeStart)
                    .HasPrecision(6)
                    .HasColumnName("TimeStart");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_review_Id");

                entity.ToTable("Review");

                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("review$review_idProduct_id_4ede3625_fk_cellphone");
            });

            modelBuilder.Entity<Smartphone>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_smartphone_product_ptr_id");

                entity.ToTable("Smartphone");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");
                entity.Property(e => e.Battery).HasMaxLength(30);
                entity.Property(e => e.Cpu)
                    .HasMaxLength(50)
                    .HasColumnName("CPU");
                entity.Property(e => e.OperatorSystem)
                    .HasMaxLength(50)
                    .HasColumnName("OperatorSystem");
                entity.Property(e => e.Others).HasMaxLength(50);
                entity.Property(e => e.Ram)
                    .HasMaxLength(50)
                    .HasColumnName("RAM");
                entity.Property(e => e.Rom)
                    .HasMaxLength(50)
                    .HasColumnName("ROM");

                entity.HasOne(d => d.Product).WithOne(p => p.Smartphone)
                    .HasForeignKey<Smartphone>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("smartphone$smartph_product_ptr_id_a0e68210_fk_cellphone");
            });
        }

        public virtual DbSet<GroupRole> GroupRole { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleClaim> RoleClaim { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<UserVerification> UserVerification { get; set; }

        ///

        public virtual DbSet<Branch> Branches { get; set; }

        public virtual DbSet<BranchProductColor> BranchProductColors { get; set; }

        public virtual DbSet<BranchPromotionProduct> BranchPromotionProducts { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Earphone> Earphones { get; set; }

        public virtual DbSet<ImageProduct> ImageProducts { get; set; }

        public virtual DbSet<Laptop> Laptops { get; set; }

        public virtual DbSet<Manufacture> Manufactures { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductColor> ProductColors { get; set; }

        public virtual DbSet<Promotion> Promotions { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Smartphone> Smartphones { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}