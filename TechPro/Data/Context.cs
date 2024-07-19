using Microsoft.EntityFrameworkCore;

namespace TechPro.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}

        public DbSet<Product> Products => Set<Product>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
        public DbSet<NetworkType> NetworkTypes => Set<NetworkType>();
        public DbSet<NetworkPackages> NetworkPackages => Set<NetworkPackages>();
        public DbSet<Customers> Customer => Set<Customers>();
        public DbSet<CartItems> CartItem => Set<CartItems>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ChatBox> ChatbBoxes => Set<ChatBox>();
        public DbSet<Inventory> Inventories => Set<Inventory>();
        public DbSet<OrderItems> OrderItem => Set<OrderItems>();
        public DbSet<Orders> Order => Set<Orders>();
        public DbSet<PackageProduct> PackageProducts => Set<PackageProduct>();
        public DbSet<PurchaseItems>? PurchaseItem => Set<PurchaseItems>();
        public DbSet<Purchases> Purchase => Set<Purchases>();
    }
}