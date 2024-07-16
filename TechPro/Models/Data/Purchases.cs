using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TechPro.Models.Data;

public class Purchases
{
    [Key]
    public int PurchaseID { get; set; }
    public int CustomerID { get; set; }
    [ForeignKey("CustomerID")]
    public virtual Customers Customers { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string TotalAmount { get; set; }
    
    public ICollection<PurchaseItems> PurchaseItems { get; set; }

}