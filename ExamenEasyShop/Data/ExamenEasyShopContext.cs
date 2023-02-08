using ExamenEasyShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenEasyShop.Data
{
    public class ExamenEasyShopContext : DbContext
    {
        public ExamenEasyShopContext(DbContextOptions<ExamenEasyShopContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetail>()
                .HasKey(ba => new { ba.OrderId, ba.ProductId });

            builder.Entity<OrderDetail>()
                .HasOne(ba => ba.Product)
                .WithMany(ba => ba.OrderDetails)
                .HasForeignKey(ba => ba.ProductId);
            builder.Entity<OrderDetail>()
                .HasOne(ba => ba.Order)
                .WithMany(ba => ba.OrderSold)
                .HasForeignKey(ba => ba.OrderId);


        }
        public DbSet<ExamenEasyShop.Models.Category> Category { get; set; } = default!;

        public DbSet<ExamenEasyShop.Models.Rol> Rol { get; set; }

        public DbSet<ExamenEasyShop.Models.Status> Status { get; set; }

        public DbSet<ExamenEasyShop.Models.User> User { get; set; }

        public DbSet<ExamenEasyShop.Models.Product> Product { get; set; }

        public DbSet<ExamenEasyShop.Models.Order> Order { get; set; }

        public DbSet<ExamenEasyShop.Models.OrderDetail> OrderDetail { get; set; }
    }
}
