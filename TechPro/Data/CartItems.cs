using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TechPro.Data;


public class CartItems
{
    [Key]
    public int CartItemID { get; set; }
    public int CartID { get; set; }
    [ForeignKey("CartID")]
    public virtual ShoppingCart ShoppingCart { get; set; }
    public int ProductID { get; set; }
    [ForeignKey("ProductID")]
    public virtual Product Product { get; set; }
    public int Quantity { get; set; }
}