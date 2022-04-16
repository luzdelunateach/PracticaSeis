using System;
using System.Linq;
using Bussiness.Services.Abstractions;
using Bussiness.Services.Implementations;
using Data.Entities;

namespace eShop
{
    public partial class eShopConsole
    {
        
        private readonly IProductService _productService;
        private readonly IDepartmentService _departmentService;
        private readonly IReportService _reportService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IRequest _requestService;

        public eShopConsole()
        {
            _productService = new ProductService();
            _departmentService = new DepartmentService();
            _reportService = new ReportService();
            _purchaseOrderService = new PurchaseOrderService();
            _shoppingCartService = new ShoppingCartService();
            _requestService = new RequestService();
        }
        #region MenuPrincipal
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
                    AgregarProducto();
                    break;
                case "2":
                    EditarProducto();
                    break;
                case "3":
                    ConsultarProductos();
                    break;
                case "4":
                    ConsultarProducto();
                    break;
                case "5":
                    EliminarProducto();
                    break;
                case "6":
                    MenuDeReportes();
                    break;
                case "7":
                    MenuOrdenesDeCompra();
                    break;
                case "8":
                default:
                    return false;
            }

            Console.WriteLine("\n¿Desea realizar otra acción? (s/n)");
            var response = Console.ReadLine();
            return response.Equals('s') ? false : true;
        }
        #endregion

        #region AdministracionDelProducto
        private void AgregarProducto()
        {
            Console.WriteLine("Agrega los valores necesarios para registrar un producto");
            Console.WriteLine("Nombre");
            var nombre = Console.ReadLine();
            Console.WriteLine("Precio");
            var precio = Console.ReadLine();
            Console.WriteLine("Descripción");
            var descripcion = Console.ReadLine();
            Console.WriteLine("Marca");
            var maraca = Console.ReadLine();
            Console.WriteLine("SKU");
            var sku = Console.ReadLine();

            Console.WriteLine("Elige el departamento:");
            // Mostrar los departamentos
            var subdepartement = SolicitarSubdepartamento();
            try
            {

                if (!Decimal.TryParse(precio, out decimal precioAux))
                {
                    throw new ApplicationException("El precio es inválido");
                }

                var product = new Product(nombre, precioAux, descripcion, maraca, sku, null);
                product.AddSubdepartment(subdepartement);
                _productService.AddProduct(product);
                Console.WriteLine("Producto agregado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EditarProducto()
        {
            Console.WriteLine("Agrega los valores necesarios para modificar el producto");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();
            Console.WriteLine("Nombre");
            var nombre = Console.ReadLine();
            Console.WriteLine("Precio");
            var precio = Console.ReadLine();
            Console.WriteLine("Descripción");
            var descripcion = Console.ReadLine();
            Console.WriteLine("Marca");
            var marca = Console.ReadLine();

            try
            {
                if (!Int32.TryParse(id, out int idAux))
                    throw new ApplicationException("No se pudo casteal el ID correctamente.");

                if (!Decimal.TryParse(precio, out decimal precioAux))
                    throw new ApplicationException("El precio es inválido");

                var producto = _productService.GetProduct(idAux);
                if (producto != null)
                {
                    var newProduct = producto;
                    newProduct.UpdateProduct(nombre, precioAux, descripcion, marca);
                    _productService.UpdateProduct(newProduct);
                    Console.WriteLine("Producto editado correctamente");
                }
                else
                {
                    Console.WriteLine("No se encontró el producto");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ConsultarProductos()
        {
            var list = _productService.GetProducts();
            list.ForEach(p =>
            {
                Console.WriteLine(p.ToString());
            });
        }

        private void ConsultarProductosStock()
        {
            var list = _productService.GetProductStock();
            list.ForEach(p =>
            {
                Console.WriteLine(p.ToString());
            });
        }

        private void ConsultarProducto()
        {
            Console.WriteLine("Proporciona el ID del producto que deseas consultar");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            if (!Int32.TryParse(id, out int idAux))
                throw new ApplicationException("No se pudo castear el ID correctamente");

            var prod = _productService.GetProduct(idAux);
            Console.WriteLine(prod.ToString());
        }

        private void EliminarProducto()
        {
            Console.WriteLine("Proporciona el ID del producto que deseas eliminar");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();

            try
            {
                if (!Int32.TryParse(id, out int idAux))
                    throw new ApplicationException("No se pudo castear el ID correctamente");

                _productService.DeleteProduct(idAux);
                Console.WriteLine("Producto eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Subdepartment SolicitarSubdepartamento()
        {
            Console.WriteLine("Elige el departamento");
            var departments = _departmentService.GetDepartments();
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {departments.ElementAt(i).Name}");
            }

            var departmentPosition = IntentarObtenerInt(Console.ReadLine());
            var department = departments.ElementAt(departmentPosition - 1);

            Console.WriteLine($"Elige el subdepartamento de {department.Name}");
            for (int i = 0; i < department.Subdeparments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {department.Subdeparments.ElementAt(i).Name}");
            }
            var subdepartmentPosition = IntentarObtenerInt(Console.ReadLine());
            var subdepartment = department.Subdeparments.ElementAt(subdepartmentPosition - 1);
            subdepartment.Department = department;
            return subdepartment;
        }

        private static int IntentarObtenerInt(string input)
        {
            return Int32.TryParse(input, out int posicion) ? posicion : throw new ApplicationException("No se pudo castear el id correctamente");
        }
        #endregion

    }
}
