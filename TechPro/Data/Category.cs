using System.ComponentModel.DataAnnotations;

namespace TechPro.Data;

public class Category
{
    [Key]
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
}