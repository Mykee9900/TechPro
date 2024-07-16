using System.ComponentModel.DataAnnotations;

namespace TechPro.Models.Data;

public class Category
{
    [Key]
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    
    public virtual ICollection<Products> Products { get; set; }
}