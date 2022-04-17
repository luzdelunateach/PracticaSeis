using System;
using System.Linq;

namespace eShop
{
    public partial class eShopConsole
    {
        #region MenuReportes
        private void MenuDeReportes()
        {
            Console.Clear();
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1. Reporte de Top 5 de productos mas caros ordenados por precio");
            Console.WriteLine("2. Reporte de Productos con 5 unidades o menos");
            Console.WriteLine("3. Reporte de productos por marcas ordenados por nombre");
            Console.WriteLine("4. Reporte de departamentos con subdepartamentos y nombres de productos");
            Console.WriteLine("5. Regresar");

            switch (Console.ReadLine())
            {
                case "1":
                    FiveExpensiveProducts();
                    break;
                case "2":
                    FiveProductsorLess();
                    break;
                case "3":
                    ProductsByBrand();
                    break;
                case "4":
                    SubdepartmentProducts();
                    break;
                case "5":
                default:
                    return;

            }
        }
        #endregion

        #region Reportes
        private void FiveExpensiveProducts()
        {
            var listProducts = _reportService.ReportFiveExpensiveProducts();

            listProducts.ForEach(lp =>
            {
                Console.WriteLine($"Producto: {lp.Name}  \t  Precio: {lp.Price}");
            });
        }

        private void FiveProductsorLess()
        {
            var listProducts = _reportService.ReportFiveProductsorLess();

            listProducts.ForEach(lp =>
            {
                Console.WriteLine($"Producto: {lp.Name}  \tPrecio: {lp.Price}");
            });
        }

        private void ProductsByBrand()
        {
            var listProducts = _reportService.ReportProductsByBrand();
            listProducts.ForEach(lp =>
            {
                Console.WriteLine($"Marca: {lp.Brand} \tProducto: {lp.Name}");
            });
        }

        private void SubdepartmentProducts()
        {
            var deparments = _reportService.ReportSubdepartmentProducts();
            foreach (var department in deparments)
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
