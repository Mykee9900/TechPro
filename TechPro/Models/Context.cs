using Microsoft.EntityFrameworkCore;
using TechPro.Models.Data;

namespace TechPro.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}
    
        public DbSet<Products>? Product { get; set; }
        public DbSet<ShoppingCart>? ShoppingCarts { get; set; }
        public DbSet<NetworkType>? NetworkTypes { get; set; }
        public DbSet<NetworkPackages>? NetworkPackage { get; set; }
        public DbSet<Customers>? Customer { get; set; }
    }
}
