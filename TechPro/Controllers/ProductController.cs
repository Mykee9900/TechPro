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

            string sessionId = GetOrCreateSessionId();
            int? customerId = GetCustomerId();

            var shoppingCart = await _context.ShoppingCarts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.SessionID == sessionId || (customerId != null && c.CustomerID == customerId));

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    SessionID = sessionId,
                    DateTime = DateTime.Now,
                    CartItems = new List<CartItems>()
                };
                _context.ShoppingCarts.Add(shoppingCart);
                await _context.SaveChangesAsync();
            }

            var cartItem = shoppingCart.CartItems
                .FirstOrDefault(ci => ci.ProductID == productId);

            if (cartItem == null)
            {
                cartItem = new CartItems
                {
                    ProductID = productId,
                    Quantity = 1,
                    CartID = shoppingCart.CartID
                };
                _context.CartItem.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            await _context.SaveChangesAsync();

            HttpContext.Session.SetInt32("CartItemCount", shoppingCart.CartItems.Sum(ci => ci.Quantity));

            var products = await _context.Products.ToListAsync();
            var viewModel = new ProductsViewModel
            {
                Products = products
            };

            ViewBag.CartItems = shoppingCart.CartItems;

            return View("Index", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            string sessionId = HttpContext.Session.GetString("SessionID");
            var cartItems = await _context.CartItem
                .Include(ci => ci.Product)
                .Where(ci => ci.ShoppingCart.SessionID == sessionId)
                .ToListAsync();

            return ViewComponent("CartItems", cartItems);
        }

        private string GetOrCreateSessionId()
        {
            if (HttpContext.Session.GetString("SessionID") == null)
            {
                var sessionId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("SessionID", sessionId);
            }

            return HttpContext.Session.GetString("SessionID");
        }

        private int? GetCustomerId()
        {
            return null; // Placeholder for actual customer ID retrieval logic
        }
    }
}
