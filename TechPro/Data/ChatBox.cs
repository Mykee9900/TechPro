using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechPro.Data;

public class ChatBox
{
    [Key]
    public int ChatID { get; set; }
    public int CustomerID { get; set; }
    [ForeignKey("CustomerID")]
    public virtual Customers Customers { get; set; }
    public string Message { get; set; }
    public DateTime DateTime { get; set; }
    public string MessageStatus { get; set; }
}