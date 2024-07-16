using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TechPro.Models.Data;

public class PackageProduct
{
    [Key]
    public int PackageProductID { get; set; }

    public int PackageID { get; set; }
    [ForeignKey("PackageID")]
    public virtual NetworkPackages NetworkPackages { get; set;}
    public int ProductID { get; set; }
    [ForeignKey("ProductID")]
    public virtual Products Products { get; set; }
    public int Quantity { get; set; }
}