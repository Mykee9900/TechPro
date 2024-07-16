using Microsoft.EntityFrameworkCore;
using TechPro.Models;

namespace TechPro.Logic
{
    public class Products
    {
        public async Task<List<Models.Product>> GetProductsAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlite("Data Source=TechDataBase.db");
            
            using (var dbContext = new Context(optionsBuilder.Options))
            {
                return await dbContext.Product.Select(p => new Models.Product()
                {
                    ProductId = p.ProductId,
                    ProductPrice = p.ProductPrice,
                    ProductName = p.ProductName
                }).ToListAsync();
            }
        }
    }
}