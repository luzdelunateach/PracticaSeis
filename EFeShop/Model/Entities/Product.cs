using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public virtual Subdepartment Subdepartment { get; set; }
        public virtual ICollection<PurchaseOrderProviderDetail> PurchaseOrderProviderDetails { get; set; }
        public Product()
        {

        }
        public Product(string name, int stock, decimal price, string sku, string description, string brand, Subdepartment? subdepartment)
        {
            Name = name;
            Stock = stock;
            Price = price;
            Sku = sku;
            Description = description;
            Brand = brand;
            Subdepartment = subdepartment;
        }
    }
}
