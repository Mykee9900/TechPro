using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechPro.Data;

public class Inventory
{
    [Key]
    public int InventID { get; set; }
    public int ProductID { get; set; }
    [ForeignKey("ProductID")]
    public virtual Product Product { get; set; }
    public int Quantity { get; set; }
}