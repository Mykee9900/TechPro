using System.Collections.Generic;
using TechPro.Data;

namespace TechPro.Models
{
    public class ShoppingCartViewModel
    {
        public List<CartItems> CartItems { get; set; } = new List<CartItems>();
    }
}