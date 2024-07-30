using System.ComponentModel.DataAnnotations;

namespace TechPro.Data;

public class NetworkPackages
{
    [Key]
    public int PackageID { get; set; }
    public string PackageName { get; set; }
    public string PackageDescription { get; set; }
    public int PackagePrice { get; set; }
    
    public ICollection<PackageProduct> PackageProduct { get; set; }

}