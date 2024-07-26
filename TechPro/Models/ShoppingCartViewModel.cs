using System.Collections.Generic;
using TechPro.Data;

namespace TechPro.Models
{
    public class ShoppingCartViewModel
    {
        public List<CartItems> CartItems { get; set; } = new List<CartItems>();
        public int Total { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}