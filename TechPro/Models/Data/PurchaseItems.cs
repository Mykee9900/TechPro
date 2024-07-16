using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TechPro.Models.Data;

public class PurchaseItems
{
    [Key]
    public int PurchaseItemID { get; set; }
    public int PurchaseID { get; set; }
    [ForeignKey("PurchaseID")]
    public virtual Purchases Purchases { get; set; }
    public int ProductID { get; set; }
    [ForeignKey("ProductID")]
    public virtual Products Products { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
}