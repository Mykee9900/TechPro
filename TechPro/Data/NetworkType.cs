using System.ComponentModel.DataAnnotations;

namespace TechPro.Data;

public class NetworkType
{
    [Key]
    public int NetworkTypeID { get; set; }
    public string NetworkTypeName { get; set; }
}