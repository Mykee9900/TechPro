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
            // Check if the user is logged in
            Customers customer;
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                // Create new customer if not logged in
                customer = new Customers
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

                HttpContext.Session.SetString("UserEmail", customer.Email);
                HttpContext.Session.SetInt32("UserId", customer.CustID);
            }
            else
            {
                var userEmail = HttpContext.Session.GetString("UserEmail");
                customer = await _context.Customer.FirstOrDefaultAsync(c => c.Email == userEmail);
            }

            // Create a new order
            var order = new Orders
            {
                CustomerID = customer.CustID,
                OrderDate = DateTime.Now,
                OrderSTatus = "Processing"
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            // Add order items
            var cartItems = await _context.CartItem.Include(ci => ci.Product).ToListAsync();
            foreach (var item in cartItems)
            {
                var orderItem = new OrderItems
                {
                    OrderID = order.OrderID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    price = item.Product.ProductPrice
                };
                _context.OrderItem.Add(orderItem);
            }

            // Save changes to database
            await _context.SaveChangesAsync();

            // Clear the cart
            _context.CartItem.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Payment successful!";
            return RedirectToAction("Index", "Product");
        }
    }
}