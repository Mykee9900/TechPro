using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TechPro.Data;
using TechPro.Models;

namespace TechPro.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            var viewModel = new ProductsViewModel
            {
                Products = products
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CartAction(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                ViewBag.ShowErrorModal = true;
                ViewBag.ErrorMessage = "The selected product does not exist.";
                return View("Index", new ProductsViewModel { Products = await _context.Products.ToListAsync() });
            }

            var products = await _context.Products.ToListAsync();
            var viewModel = new ProductsViewModel
            {
                Products = products
            };

            return View("Index", viewModel);
        }
    }
}