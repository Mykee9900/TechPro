using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechPro.Data;
using TechPro.Models;

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
                    // Set the user as authenticated (you can use cookies or sessions)
                    HttpContext.Session.SetString("UserEmail", customer.Email);
                    HttpContext.Session.SetInt32("UserId", customer.CustID);

                    TempData["SuccessMessage"] = "Login successful!";
                    return RedirectToAction("Users", "Users");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // If we got this far, something failed; redisplay form
            return View("Login", model);
        }

        public IActionResult Logout()
        {
            // Clear the user session
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Users()
        {
            return View("UserAccount");
        }
    }
}