using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TechPro.Data
{
    public class ShoppingCart
    {
        [Key] public int CartID { get; set; }
        public string SessionID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime DateTime { get; set; }

        public virtual ICollection<CartItems> CartItems { get; set; }
    }
}