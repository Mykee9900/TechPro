using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TechPro.Models.Data;

public class OrderItems
{
    [Key]
    public int OrderItemID { get; set; }
    public int OrderID { get; set; }
    [ForeignKey("OrderID")]
    public virtual Orders Orders { get; set; }
    public int ProductID { get; set; }
    [ForeignKey("ProductID")]
    public virtual Products Products { get; set; }
    public int Quantity { get; set; }
    public int price { get; set; }
}