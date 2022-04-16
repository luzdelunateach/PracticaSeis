using System;
using System.Collections.Generic;
using Data.Entities;

namespace Bussiness
{
    public class TestData
    {
        public static List<Product> ProductList = new List<Product>()
        {
            new Product("Silla", 100M, "Silla color morado", "Muebleria Diana", "S1S2", 1),
            new Product("Escritorio", 300M, "Escritorio de madera", "Dico", "S1S3", 2),
            new Product("Sofa", 500M, "Gris de terciopelo", "Salinas", "S1S4", 3)
        };

        public static List<Department> DepartmentList = new List<Department>()
        {
            new Department("Electrónicos", new List<Subdepartment> {
                new Subdepartment("TV's"),
                new Subdepartment("Celulares"),
                new Subdepartment("Audio")
            }),
            new Department("Muebles", new List<Subdepartment> {
                new Subdepartment("Cocina"),
                new Subdepartment("Comedor"),
                new Subdepartment("Sala")
            }),
            new Department("Alimentos", new List<Subdepartment> {
                new Subdepartment("Lacteos"),
                new Subdepartment("Carnes frías"),
                new Subdepartment("Pastas")
            })
        };

        public static List<ShoppingCart> ShoppingCartList = new List<ShoppingCart>()
        {
       
        };

        public static List<Provider> GetProviders()
        {
            var providers = new List<Provider>();

            var p1 = new Provider(1, "Gamesa", "proveedor@gamesa.com");
            p1.AddAddress("islas 123","mexicali");
            p1.AddPhoneNumber("6861234567");
            providers.Add(p1);

            var p2 = new Provider(2, "Levis", "proveedor@levis.com");
            p2.AddAddress("islas levis 123", "tijuana");
            p2.AddPhoneNumber("6641231656");
            providers.Add(p2);

            var p3 = new Provider(3, "Mercado Chuchita", "proveedor@chuchita.com");
            p3.AddAddress("islas chu 123", "tijuana");
            p3.AddPhoneNumber("6641231644");
            providers.Add(p3);

            return providers;
        }
    }
}
