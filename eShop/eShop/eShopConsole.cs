using System;
using System.Linq;
using Bussiness.Models;
using Bussiness.Services.Abstractions;
using Bussiness.Services.Implementations;
using Data.Entities;

namespace eShop
{
    public partial class eShopConsole
    {
        /*#region Servicios
        private readonly IProductService _productService;
        private readonly ISubdepartmentService _subdepartmentService;
        private readonly IReportService _reportService;
        private readonly IProviderService _providerService;
        private readonly IPurchaseOrderProviderService _PurchaseOrderProviderService;

        public eShopConsole()
        {
            _productService = new ProductService();
            _subdepartmentService = new SubdepartmentService();
            _reportService = new ReportService();
            _providerService = new ProviderService();
            _PurchaseOrderProviderService = new PurchaseOrderProviderService();
        }
        #endregion
        #region MenuClienteoAdiministrador
        public bool MenuClienteAdministrador()
        {
            Console.Clear();
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1. Menu de Administracion");
            Console.WriteLine("2. Menu de Cliente");
            Console.WriteLine("3. Salir");
            switch (Console.ReadLine())
            {
                case "1":
                    MainMenu();
                    break;
                case "2":
                    MenuCliente();
                    break;
                case "3":
                default:
                    return false;
            }
            Console.WriteLine("\n¿Desea realizar otra acción? (s/n)");
            var response = Console.ReadLine();
            return response.Equals('s') ? false : true;
        }
        #endregion
            #region MenuAdministrador
        public bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Editar Producto");
            Console.WriteLine("3. Consultar Productos");
            Console.WriteLine("4. Consultar Producto");
            Console.WriteLine("5. Eliminar Producto");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Ordenes de compra");
            Console.WriteLine("8. Salir");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    AgregarProducto();
                    break;
                case "2":
                    Console.Clear();
                    EditarProducto();
                    break;
                case "3":
                    Console.Clear();
                    ConsultarProductos();
                    break;
                case "4":
                    Console.Clear();
                    ConsultarProducto();
                    break;
                case "5":
                    Console.Clear();
                    EliminarProducto();
                    break;
                case "6":
                    Console.Clear();
                    MenuDeReportes();
                    break;
                case "7":
                    Console.Clear();
                    MenuOrdenesDeCompra();
                    break;
            }

            Console.WriteLine("\n¿Desea realizar otra acción? (s/n)");
            var response = Console.ReadLine();
            return response.Equals('s') ? false : true;
        }
        #endregion

        #region AdministracionDelProducto
        private void AgregarProducto()
        {
            var productRegistry = new ProductRegistryDto();
            Console.WriteLine("Agrega los valores necesarios para registrar un producto: \n");
            Console.Write("Nombre del Producto:");
            productRegistry.Name = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Cantidad del Stock:");
            productRegistry.Stock = IntentarObtenerInt(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Precio del Producto: ");
            var precio = Console.ReadLine();
            if (!Decimal.TryParse(precio, out decimal precioAux))
            {
                Console.WriteLine("El precio es inválido");
                Console.ReadLine();
                return;
            }
            productRegistry.Price = precioAux;
            Console.Write("\n");
            Console.Write("Descripción del Producto: ");
            productRegistry.Description = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Marca del Producto: ");
            productRegistry.Brand = Console.ReadLine();
            Console.Write("\n");
            Console.Write("SKU: ");
            productRegistry.Sku = Console.ReadLine();
            Console.WriteLine("***Listado de Subdepartamentos***");
            var subdepartments = _subdepartmentService.GetAll();
            foreach (var subdepartment in subdepartments)
            {
                Console.WriteLine($"Id: {subdepartment.Id}\tSubdepartamento: {subdepartment.Name}\tDepartamento: {subdepartment.DepartmentName}\n");
            }
            Console.WriteLine("Ingresa el id del Subdepartamento: ");
            productRegistry.SubdepartmentId = IntentarObtenerInt(Console.ReadLine());

            try
            {
                productRegistry.Validation();
                _productService.RegisterProduct(productRegistry);
                Console.WriteLine("Producto se ha agregado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadLine();
            }
        }


        private void ConsultarProductos()
        {
            Console.WriteLine("Lista de Productos:\n");
            try
            {
                var products = _productService.GetAll();
                Console.WriteLine("Productos Disponibles");
                foreach (var product in products)
                {

                    Console.WriteLine($"Id: {product.Id}\tNombre: {product.Name}\tStock: {product.Stock}\tPrecio: {product.Price:C}\tSKU: {product.Sku}\nDescripción: {product.Description}\tSKU: {product.Sku}\tMarca: {product.Brand}\tSubdepartamento: {product.SudepartmentName}\nDepartamento: {product.DepartmentName}\n");
                    Console.WriteLine("--------------------------------------------------------------------------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadLine();
            }
        }

        private void ConsultarProductosElegir()
        {
            Console.WriteLine("Lista de Productos:\n");
            try
            {
                var products = _productService.GetAll();
                Console.WriteLine("Productos Disponibles");
                foreach (var product in products)
                {

                    Console.WriteLine($"Id: {product.Id}\tNombre: {product.Name}\tStock: {product.Stock}\tPrecio: {product.Price:C}\tSKU: {product.Sku}\nDescripción: {product.Description}\tSKU: {product.Sku}\tMarca: {product.Brand}\tSubdepartamento: {product.SudepartmentName}\nDepartamento: {product.DepartmentName}\n");
                    Console.WriteLine("--------------------------------------------------------------------------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ConsultarProducto()
        {
            Console.WriteLine("**Porfavor ingrese el Id del Producto que desea consultar***");
            Console.Write("Id del Producto: ");
            try
            {
                var input = IntentarObtenerInt(Console.ReadLine());
                var product = _productService.GetProduct(input);
                Console.WriteLine($"Id: {product.Id}\tNombre: {product.Name}\tStock: {product.Stock}\tPrecio: {product.Price:C}\tSKU: {product.Sku}\nDescripción: {product.Description}\tSKU: {product.Sku}\tMarca: {product.Brand}\tSubdepartamento: {product.SudepartmentName}\nDepartamento: {product.DepartmentName}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadLine();
            }
        }
        private void EditarProducto()
        {
            ConsultarProductos();
            var con = false;
            var producto = new ProductDto();
            try
            {
                do
                {
                    Console.WriteLine("**Porfavor ingrese el Id del Producto que desea editar***");
                    Console.Write("Id del Producto: ");
                    var id = IntentarObtenerInt(Console.ReadLine());
                    producto = _productService.GetProduct(id);
                    if (producto == null)
                    {
                        Console.WriteLine("The course does not exist.");
                        return;
                    }
                    Console.WriteLine("Los campos que se pueden editar son: \n1.Nombre\n2.Precio\n3.Descripcion\n4.Marca");
                    Console.Write("Ingrese el nombre del campo: ");
                    var campo = Console.ReadLine();
                    switch (campo.ToLower())
                    {
                        case "nombre":
                            Console.Write("Nombre del Producto: ");
                            var nombre = Console.ReadLine();
                            producto.Name = nombre;
                            break;
                        case "precio":
                            Console.Write("Precio: ");
                            var precio = Console.ReadLine();
                            if (!Decimal.TryParse(precio, out decimal precioAux))
                            {
                                Console.WriteLine("El precio es inválido");
                                Console.ReadLine();
                                return;
                            }
                            producto.Price = precioAux;
                            break;
                        case "descripcion":
                            Console.Write("Descripcion: ");
                            var descripcion = Console.ReadLine();
                            producto.Description = descripcion;
                            break;
                        case "marca":
                            Console.Write("Marca: ");
                            var marca = Console.ReadLine();
                            producto.Brand = marca;
                            break;
                    }
                    _productService.UpdateProduct(producto);
                    Console.WriteLine("¿Deseas editar otro producto? (y/n)");
                    var response = Console.ReadLine();
                    con = response.ToLower().Equals("y");
                } while (con);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadLine();
            }
        }
        private void EliminarProducto()
        {
            Console.WriteLine("***Lista de Productos***");
            try
            {
                var products = _productService.GetAll();
                foreach (var product in products)
                {

                    Console.WriteLine($"Id: {product.Id}\tNombre: {product.Name}\tStock: {product.Stock}\tSKU: {product.Sku}\tMarca: {product.Brand}\n");
                    Console.WriteLine("--------------------------------------------------------------------------");
                }
                Console.WriteLine("Selecciona el Id del producto que deseas eliminar");
                Console.Write("Id del Producto: ");
                var input = IntentarObtenerInt(Console.ReadLine());
                _productService.Delete(input);
                Console.WriteLine("El producto se ha eliminado.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
        }

        private static int IntentarObtenerInt(string element)
        {
            return Int32.TryParse(element, out int result) ? result : throw new ApplicationException("Error, el ID ingresado no se puede castear");
        }
        #endregion*/

    }
}
