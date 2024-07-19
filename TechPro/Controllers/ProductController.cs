using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechPro.Data;
using TechPro.Models;

namespace TechPro.Controllers;

public class ProductController : Controller
{
    private readonly Context _context;

    public ProductController(Context context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<IActionResult> Index(ProductsViewModel vm)
    {
        var products = await GetProductsAsync();
        vm.Products = products;
        return View(vm);
    }

    public IActionResult CartACtion()
    {
        return View("~/Views/Product/Index.cshtml");
    }
}