using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechPro.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public virtual ICollection<CartItems> CartItems { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
        public ICollection<PackageProduct> PackageProduct { get; set; }
        public ICollection<PurchaseItems> PurchaseItems { get; set; }
    }
}