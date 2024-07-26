using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechPro.Data;
using TechPro.Models;
using System.Threading.Tasks;
using System.Linq;

namespace TechPro.Controllers
{
    public class UsersController : Controller
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Login", new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = await _context.Customer
                    .FirstOrDefaultAsync(c => c.Email == model.Email && c.Password == model.Password);

                if (customer != null)
                {
                    HttpContext.Session.SetString("UserEmail", customer.Email);
                    HttpContext.Session.SetInt32("UserId", customer.CustID);

                    TempData["SuccessMessage"] = "Login successful!";
                    return RedirectToAction("UserAccount");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View("Login", model);
        }

        public IActionResult Logout()
        {
            // Clear the user session
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> UserAccount()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var userEmail = HttpContext.Session.GetString("UserEmail");
            var customer = await _context.Customer
                .Include(c => c.Orders)
                    .ThenInclude(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(c => c.Email == userEmail);

            if (customer == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new UsersViewModel
            {
                Customer = customer,
                Orders = customer.Orders.ToList()
            };

            return View(viewModel);
        }
    }
}