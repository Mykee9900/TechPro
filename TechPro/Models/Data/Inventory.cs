using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechPro.Models.Data;

public class Inventory
{
    [Key]
    public int InventID { get; set; }
    public int ProductID { get; set; }
    [ForeignKey("ProductID")]
    public virtual Products Products { get; set; }
    public int Quantity { get; set; }
}