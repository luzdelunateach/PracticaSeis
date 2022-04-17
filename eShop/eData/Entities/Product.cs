using System;
using System.Security.Cryptography.X509Certificates;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public string Sku { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public Subdepartment Subdepartment { get; private set; }

        private int _idSeed = 4;

        public Product(string name, decimal price, string description, string brand, string sku, int? id, int stock = 1)
        {
            if (price < 0)
                throw new InvalidOperationException("El precio no puede ser menor a cero.");

            if (stock <= 0)
                throw new InvalidOperationException("El stock tiene que ser mayor a uno.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede ser vacio");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("La descripción no puede ser vacia");

            if (string.IsNullOrEmpty(brand))
                throw new ArgumentNullException("La marca no puede ser vacia");

            if (string.IsNullOrEmpty(sku))
                throw new ArgumentNullException("El sku no puede ser vacio");

            Id = id ?? _idSeed++;
            Name = name;
            Price = price;
            Description = description;
            Brand = brand;
            Sku = sku;
            Stock = stock;
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
