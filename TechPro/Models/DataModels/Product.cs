namespace TechPro.Models;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductPrice { get; set; }
    public int CategoryID { get; set; }
    public string Category { get; set; }
}