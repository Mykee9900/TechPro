using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TechPro.Data;

public class Orders
{
    [Key]
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    [ForeignKey("CustomerID")]
    public virtual Customers Customers { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderSTatus { get; set; }
    
    public ICollection<OrderItems> OrderItems { get; set; }
}