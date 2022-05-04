using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Subdepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Department Department { get; set; }

        public Subdepartment()
        {

        }
        public Subdepartment(string name, ICollection<Product> products)
        {
            
            Name = name;
            Products = products;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
