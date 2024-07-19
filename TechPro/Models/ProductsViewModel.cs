using TechPro.Data;

namespace TechPro.Models;

public class ProductsViewModel
{
    public List<Product>? Products { get; set; }

    public List<Product>? NetworkProducts => Products?.Where(p => p.CategoryID == 2).ToList();
}