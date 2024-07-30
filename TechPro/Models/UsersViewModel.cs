using System.Collections.Generic;
using TechPro.Data;

namespace TechPro.Models
{
    public class UsersViewModel
    {
        public Customers Customer { get; set; }
        public List<Orders> Orders { get; set; }
    }
}