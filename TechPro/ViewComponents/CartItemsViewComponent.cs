using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TechPro.Data;

namespace TechPro.ViewComponents
{
    public class CartItemsViewComponent : ViewComponent
    {
        private readonly Context _context;

        public CartItemsViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionId = HttpContext.Session.GetString("SessionID");
            var cartItems = await _context.CartItem
                .Include(ci => ci.Product)
                .Where(ci => ci.ShoppingCart.SessionID == sessionId)
                .ToListAsync();

            return View(cartItems);
        }
    }
}