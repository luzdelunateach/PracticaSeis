using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Subdepartment
    {
        //public int Id { get; set; }
        public string Name { get; private set; }
        public Department Department { get; set; }
        public List<Product> Products { get; set; } //= new() || new List<Product>() ;

        public Subdepartment(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede ser vacio.");

            Name = name;
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
