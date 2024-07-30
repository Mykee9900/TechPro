using System.ComponentModel.DataAnnotations;

namespace TechPro.Data;

public class Customers
{
    [Key]
    public int CustID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    
    public ICollection<ChatBox> ChatBox { get; set; }
    public ICollection<Orders> Orders { get; set; }
    public ICollection<Purchases> Purchases { get; set; }


}