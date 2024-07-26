using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechPro.Data;
using TechPro.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TechPro.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly Context _context;

        public CheckOutController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cartItems = await _context.CartItem.Include(ci => ci.Product).ToListAsync();
            var vm = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                Total = cartItems.Sum(ci => ci.Product.ProductPrice * ci.Quantity)
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(ShoppingCartViewModel model)
        {
            // Create new customer
            var customer = new Customers
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            // Clear the cart items
            string sessionId = HttpContext.Session.GetString("SessionID");
            var cartItems = await _context.CartItem.Where(ci => ci.ShoppingCart.SessionID == sessionId).ToListAsync();
            _context.CartItem.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            // Update the cart item count in the session
            HttpContext.Session.SetInt32("CartItemCount", 0);

            TempData["SuccessMessage"] = "Payment successful!";

            return RedirectToAction("Index", "Product");
        }
    }
}