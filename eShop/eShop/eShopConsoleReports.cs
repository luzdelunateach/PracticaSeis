using System;
using System.Linq;

namespace eShop
{
    public partial class eShopConsole
    {
        #region Menu
        private void MenuDeReportes()
        {
            Console.Clear();
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1. Top 5 de productos más caros ordenados por precio más alto");
            Console.WriteLine("2. Productos con 5 unidades o menos ordenados por unidades");
            Console.WriteLine("3. Nombre de productos por marcas ordenados por nombre");
            Console.WriteLine("4. Agrupación de departamentos con subdepartamentos y nombres de productos");
            Console.WriteLine("5. Regresar");

            switch (Console.ReadLine())
            {
                case "1":
                    Top5ExpensiveProductsOrderedByPrice();
                    break;
                case "2":
                    Products5orLessUnitsOrderedByUnits();
                    break;
                case "3":
                    ProductsByBrandOrderedByProductName();
                    break;
                case "4":
                    GroupDepartmentGroupSubdepartmentProducts();
                    break;
                case "5":
                default:
                    return;

            }
        }
        #endregion

        #region Reportes
        private void Top5ExpensiveProductsOrderedByPrice()
        {
            var listProducts = _reportService.Top5ExpensiveProductsOrderedByPrice();

            foreach (var prod in listProducts)
            {
                Console.WriteLine($"Producto: {prod.Name},  Precio: {prod.Price}");
            }
        }

        private void Products5orLessUnitsOrderedByUnits()
        {
            var listProducts = _reportService.Products5orLessUnitsOrderedByUnits();

            foreach (var prod in listProducts)
            {
                Console.WriteLine($"Producto: {prod.Name},  Precio: {prod.Price}");
            }
        }

        private void ProductsByBrandOrderedByProductName()
        {
            var listProducts = _reportService.ProductsByBrandOrderedByProductName();
            listProducts.ForEach(b =>
            {
                Console.WriteLine($"Marca: {b.Brand}");
                b.Productos.ForEach(p =>
                {
                    Console.WriteLine($"Producto: {p.Name}");
                });
            });
        }

        private void GroupDepartmentGroupSubdepartmentProducts()
        {
            var departments = _reportService.GroupDepartmentGroupSubdepartmentProducts();
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Department}");
                foreach (var subdepartment in department.Subdepartaments)
                {
                    Console.WriteLine($"{subdepartment.Subdepartment}");
                    foreach (var product in subdepartment.Productos)
                    {
                        Console.WriteLine($"Producto: {product.Name}");
                    }
                }
            }

        }
        #endregion
    }
}
