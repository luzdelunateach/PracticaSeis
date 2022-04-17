using System;
using System.Linq;
using Bussiness.Services.Abstractions;
using Bussiness.Services.Implementations;
using Data.Entities;

namespace eShop
{
    public partial class eShopConsole
    {
        #region Servicios
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
            Console.WriteLine("Sku");
            var sku = Console.ReadLine();

            Console.WriteLine("Elige el departamento:");
            
            var subdepartement = MostrarSubdepartamento();
            try
            {
                if (!Decimal.TryParse(precio, out decimal precioAux))
                {
                    throw new ApplicationException("Ingresar una precio valido");
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
            Console.WriteLine("Ingresa el Id para editar un producto");
            Console.WriteLine("Id");
            var id = IntentarObtenerInt(Console.ReadLine());
            try
            {
                var product = _productService.GetProduct(id);
                Console.WriteLine("Ingrese el nuevo nombre del producto: ");
                var n = Console.ReadLine();
                if (String.IsNullOrEmpty(n))
                {
                    throw new ArgumentNullException("Ingresar un nombre correcto");
                }
                Console.WriteLine("Ingrese la nueva descripción");
                var d = Console.ReadLine();
                if (String.IsNullOrEmpty(d))
                {
                    throw new ArgumentNullException("Ingresar una descripcion correcta");
                }
                Console.WriteLine("Ingresar el nuevo precio");
                var p = Console.ReadLine();
                if (!decimal.TryParse(p, out decimal priceAux))
                {
                    throw new ApplicationException("Ingresar una precio valido");
                }
                var productTwo = new Product(n, priceAux, d, product.Brand, product.Sku,id);
                _productService.UpdateProduct(productTwo);
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
            Console.WriteLine("Ingrese el ID del producto que deseas consultar");
            Console.WriteLine("Id:");
            var id = IntentarObtenerInt(Console.ReadLine());
            var prod = _productService.GetProduct(id);
            Console.WriteLine(prod.ToString());
        }

        private void EliminarProducto()
        {
            Console.WriteLine("Ingrese el ID del producto que desea eliminar");
            Console.WriteLine("Id:");
            var id = IntentarObtenerInt(Console.ReadLine());
            _productService.DeleteProduct(id);
            Console.WriteLine("Producto eliminado exitosamente");
        }

        private Subdepartment MostrarSubdepartamento()
        {
            Console.WriteLine("Ingresa el numero del departamento");
            var departments = _departmentService.GetDepartments();
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine($"No: {i + 1}. {departments.ElementAt(i).Name}");
            }
            var noDeparment = IntentarObtenerInt(Console.ReadLine());
            var department = departments.ElementAt(noDeparment - 1);

            Console.WriteLine($"Ingresa el numero subdepartamento de {department.Name}");
            for (int i = 0; i < department.Subdeparments.Count; i++)
            {
                Console.WriteLine($"No: {i + 1}. {department.Subdeparments.ElementAt(i).Name}");
            }
            var noSubdeparment = IntentarObtenerInt(Console.ReadLine());
            var subdepartment = department.Subdeparments.ElementAt(noSubdeparment - 1);
            subdepartment.Department = department;
            return subdepartment;
        }

        private static int IntentarObtenerInt(string element)
        {
            return Int32.TryParse(element, out int result) ? result : throw new ApplicationException("Error, el ID ingresado no se puede castear");
        }
        #endregion

    }
}
