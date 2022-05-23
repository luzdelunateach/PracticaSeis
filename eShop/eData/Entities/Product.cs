using System;
using System.Collections.Generic;

namespace Data.Entities
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
        public Product(string name, int stock, decimal price, string sku, string description, string brand, Subdepartment subdepartment)
        {
            
            Name = name;
            Stock = stock;
            Price = price;
            Sku = sku;
            Description = description;
            Brand = brand;
            Subdepartment = subdepartment;
        }
        public void AddSubdepartment(Subdepartment subdepartment)
        {
            if (subdepartment == null)
                throw new ArgumentNullException("Se requiere un subdepartamento");

            Subdepartment = subdepartment;
        }

        public void UpdateProduct(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public void UpdateStock(int stock)
        {
            if (stock <= 0)
                throw new ArgumentNullException("El stock debe ser mayor a 0");

            Stock = stock;
        }

        public void UpdateStockShop(int stock)
        {
            if (stock < 0)
                throw new ArgumentNullException("Producto no disponible");

            Stock = stock;
        }

        public override string ToString()
        {
            return $"Id:{Id},\tNombre:{Name},\tMarca:{Brand},\tSKU:{Sku},\tStock:{Stock},\tDescripcion:{Description},\tSubdepartamento:{Subdepartment?.Name},\tDepartamento:{Subdepartment?.Department?.Name}";
        }
    }
}
