using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Projet_2022.Models.Assoc;
using Projet_2022.Models.Entities;

namespace Projet_2022.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {


            #region ProductTag
            builder.Entity<ProductTag>().HasKey(pt => new
            {
                pt.IdProduct,
                pt.IdTag
            });
            builder.Entity<ProductTag>().HasOne(p => p.Product).WithMany(pt => pt.ProductTags).HasForeignKey(t => t.IdProduct).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ProductTag>().HasOne(t => t.Tag).WithMany(pt => pt.TagProducts).HasForeignKey(p => p.IdTag).OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region ProductOption
            builder.Entity<ProductOption>().HasKey(po => new
            {
                po.IdProduct,
                po.IdOption
            });
            builder.Entity<ProductOption>().HasOne(p => p.Product).WithMany(po => po.ProductOptions).HasForeignKey(o => o.IdProduct).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ProductOption>().HasOne(p=>p.Option).WithMany(po=>po.ProductsOption).HasForeignKey(o => o.IdOption).OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Option
            builder.Entity<Option>().HasOne(b => b.OptionGroup).WithMany(og => og.Options).HasForeignKey(b => b.IdOptionGroup);
            #endregion

            #region Order 
            builder.Entity<Order>().HasOne(o => o.Coupon).WithMany(c => c.Orders).HasForeignKey(o => o.IdCoupon).IsRequired(false);
            builder.Entity<Order>().HasOne(O => O.User).WithMany(u => u.Orders).HasForeignKey(o => o.IdUser).IsRequired(false);
            #endregion 

            #region OrderItem
            builder.Entity<OrderItem>().HasOne(o => o.Product).WithMany(p => p.OrderItems).HasForeignKey(o => o.IdProduct);
            builder.Entity<OrderItem>().HasOne(oi => oi.Order).WithMany(o => o.OrderItems).HasForeignKey(oi => oi.IdOrder);
            #endregion

            #region  productgalleryimage
            builder.Entity<ProductGalleryImage>().HasOne(pgi => pgi.Product).WithMany(p => p.ProductGalleryImages).HasForeignKey(o => o.IdProduct);
            #endregion

            #region  Product
            builder.Entity<Product>().HasOne(p => p.Brand).WithMany(p => p.Products).HasForeignKey(o => o.IdBrand);
            builder.Entity<Product>().HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(o => o.IdCategory);
            #endregion

            #region Category
            builder.Entity<Category>().HasMany(c => c.Categories).WithOne(c => c.ParentCategory).HasForeignKey(c=>c.IdParentCategory).IsRequired(false);
            #endregion

            #region User
            builder.Entity<User>().HasOne(c => c.Country).WithMany(c => c.Users).HasForeignKey(u => u.IdCountry).IsRequired(false);
            builder.Entity<User>().HasOne(u => u.Job).WithMany(j => j.Users).HasForeignKey(u => u.IdJob).IsRequired(false);
            builder.Entity<User>().HasOne(u => u.Manager).WithMany(m => m.Employees).HasForeignKey(u => u.IdManager).IsRequired(false);
            #endregion


            base.OnModelCreating(builder);


        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductGalleryImage> ProductGalleryImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductTag> ProductsTags { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionGroup> OptionGroups { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
