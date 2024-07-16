using System.ComponentModel.DataAnnotations;

namespace TechPro.Models.Data;

public class ShoppingCart
{
    [Key]
    public int CartID { get; set; }
    public int CustomerID { get; set; }
    public DateTime DateTime { get; set; }
    
    public virtual ICollection<CartItems> CartItems { get; set; }
}