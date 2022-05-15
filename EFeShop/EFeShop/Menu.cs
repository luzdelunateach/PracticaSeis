using EFeShop.Service.Abstraction;
using EFeShop.Service.Implementation;
using Model.Entities;
using Share.Dto;
using Share.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop
{
    public class Menu
    {
        private readonly IProductService _productService;
        private readonly ISubdepartmentService _subdepartmentService;
        private readonly IReportService _reportService;
        private readonly IProviderService _providerService;
        private readonly IPurchaseOrderProviderService _PurchaseOrderProviderService;
        private readonly IPurchaseOrderCart _purchaseOrderCart;
        static List<Product> ProductL = new List<Product>();
        static decimal totalC = 0.0m;
        //  static CartShoppingDto listShopProducts = new CartShoppingDto();
        public Menu()
        {
            _productService = new ProductService();
            _subdepartmentService = new SubdepartmentService();
            _reportService = new ReportService();
            _providerService = new ProviderService();
            _PurchaseOrderProviderService = new PurchaseOrderProviderService();
            _purchaseOrderCart = new PurchaseOrderCartService();
        }

        public bool Show()
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Admin Menu");
            Console.WriteLine("2. Cliente Menu");
            Console.Write("Tu opción: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    MenuAdmin();
                    break;
                case "2":
                    Console.Clear();
                    MenuClient();
                    break;
                default:
                    return false;
            }
            return true;
        }

        public void MenuClient()
        {
            Console.Clear();
            Console.WriteLine("Elige una opción");
            Console.WriteLine("1. Agregar productos al carrito");
            Console.WriteLine("2. Ver carrito");
            Console.WriteLine("3. Eliminar producto ");
            Console.WriteLine("4. Hacer Pedido");
            Console.WriteLine("5. Ver Pedido");
            Console.Write("Tu opción: ");
            switch (Console.ReadLine())
            {
                case "1":
                    AgregarProductoCarrito();
                    break;
                case "2":
                    ConsultarCarrito();
                    break;
                case "3":
                    EliminarProductoCarrito();
                    break;
                case "4":
                    HacerPedidoCarrito();
                    break;
                case "5":
                    ConsultarOrdenes();
                    break;
                default:
                    return;
            }
        }
        public void MenuAdmin()
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Editar Producto");
            Console.WriteLine("3. Consultar Productos");
            Console.WriteLine("4. Consultar Producto");
            Console.WriteLine("5. Eliminar Producto");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Ordenes de compra");
            Console.Write("Tu opción: ");
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
                default:
                    return;
            }
        }

        public void MenuDeReportes()
        {
            Console.Clear();
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1. Top 5 de productos más caros ordenados por precio más alto");
            Console.WriteLine("2. Productos con 5 unidades o menos ordenados por unidades");
            Console.WriteLine("3. Nombre de productos por marcas ordenados por nombre");
            Console.WriteLine("4. Ordenados por departamentos y subdepartamentos");
            Console.Write("Tu opción: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Top5ExpensiveProducts();
                    break;
                case "2":
                    ProductsOrderedByUnits();
                    break;
                case "3":
                    ProductsByBrand();
                    break;
                case "4":
                    ProductsByDepartment();
                    break;
                case "5":
                default:
                    return;
            }
        }

        private bool MenuOrdenesDeCompra()
        {
            Console.Clear();
            Console.WriteLine("Elige una opción");
            Console.WriteLine("1. Agregar orden de compra");
            Console.WriteLine("2. Ver ordenes de compra");
            Console.WriteLine("3. Cambiar estatus");
            Console.WriteLine("4. Reporte de Ordenes de compra con estado pagado de los ultimos 7 dias");
            Console.WriteLine("5. Reporte de Ordenes de compra que abastecieron la silla");
            Console.WriteLine("6. Reporte de Compras de Salchichon pendientes de pagar al proveedor");
            Console.WriteLine("7. Reporte de Producto con unidades mas compradas");
            Console.WriteLine("8. Regresar");
            Console.Write("Tu opción: ");
            switch (Console.ReadLine())
            {
                case "1":
                    AddPurchaseOrder();
                    break;
                case "2":
                    ConsultarOrdenesDeCompra();
                    break;
                case "3":
                    CambiarEstatusOrdenCompra();
                    break;
                case "4":
                    Last7DaysOrders();
                    break;
                case "5":
                    PurchaseOrdersChair();
                    break;
                case "6":
                    PurchaseOrdersSalchichonPending();
                    break;
                case "7":
                    MorePurchasedUnits();
                    break;
                default:
                    return false;
            }
            return true;
        }
        #region Products
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
        #endregion

        #region Reports
        private void Top5ExpensiveProducts()
        {
            Console.WriteLine("***Reporte***");
            try
            {
                var listProducts = _reportService.Top5ExpensiveProducts();

                foreach (var prod in listProducts)
                {
                    Console.WriteLine($"Producto: {prod.Name}\tPrecio: {prod.Price:C}\n");
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
        private void ProductsOrderedByUnits()
        {
            Console.WriteLine("***Reporte***");
            try
            {
                var listProducts = _reportService.ProductsOrderedByUnits();
                foreach (var prod in listProducts)
                {
                    Console.WriteLine($"Producto: {prod.Name}\tPrecio: {prod.Price:C}\n");
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

        private void ProductsByBrand()
        {
            Console.WriteLine("***Reporte***");
            try
            {
                var listProducts = _reportService.ProductsByBrand();
                foreach (var prod in listProducts)
                {
                    Console.WriteLine($"Producto: {prod.Name}\tMarca: {prod.Brand}\tPrecio: {prod.Price:C}\n");
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

        private void ProductsByDepartment()
        {
            Console.WriteLine("***Reporte***");
            try
            {
                var listProducts = _reportService.ProductsByBrand();
                foreach (var prod in listProducts)
                {
                    Console.WriteLine($"Producto: {prod.Name}\tMarca: {prod.Brand}\tPrecio: {prod.Price:C}\tDepartamento: {prod.DepartmentName}\tSubdepartamento: {prod.SudepartmentName}\n");
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

        private void ProductsStock()
        {
            Console.WriteLine("*******Productos*******");
            try
            {
                var listProducts = _productService.GetStockProducts();
                foreach (var prod in listProducts)
                {
                    Console.WriteLine($"Id: {prod.Id}\tProducto: {prod.Name}\tMarca: {prod.Brand}\tPrecio: {prod.Price:C}\nDepartamento: {prod.DepartmentName}\tSubdepartamento: {prod.SudepartmentName}\n");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region OrdenesCompraProveedor
        private void AddPurchaseOrder()
        {
            var order = new OrderProviderRegestryDto();
            Console.WriteLine("***Pedido para Resurtir Producto***");
            try
            {
                bool seguir = true;
                while (seguir)
                {
                    Console.WriteLine("Elige al proveedor");
                    ConsultarProveedor();
                    Console.Write("Id: ");
                    var IdP = IntentarObtenerInt(Console.ReadLine());
                    order.ProviderId = IdP;
                    Console.WriteLine("Elige al Producto");
                    ConsultarProductosElegir();
                    Console.Write("Id: ");
                    var IdPro = IntentarObtenerInt(Console.ReadLine());
                    order.ProductoId = IdPro;
                    var product = _productService.GetProduct(IdPro);
                    Console.WriteLine($"\n¿Que cantidad de {product.Name}(s) deseas comprar?");
                    var cantidad = IntentarObtenerInt(Console.ReadLine());
                    order.Cantidad = cantidad;
                    var total = product.Price * cantidad;
                    order.Total = total;
                    order.Validation();
                    _PurchaseOrderProviderService.RegisterOrder(order);
                    Console.WriteLine("Producto se ha agregado correctamente");
                    Console.WriteLine("¿Desea agregar otro producto? (s/n)");
                    var opcion = Console.ReadLine();
                    seguir = opcion.ToLower().Equals("s") ? true : false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadLine();
            }
        }

        private void ConsultarProveedor()
        {
            try
            {
                var proveedor = _providerService.GetAll();
                Console.WriteLine("Productos Disponibles");
                foreach (var provider in proveedor)
                {

                    Console.WriteLine($"Id: {provider.Id}\tNombre: {provider.Name}\tEmail: {provider.Email}\n");
                    Console.WriteLine("--------------------------------------------------------------------------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ConsultarOrdenesDeCompra()
        {
            try
            {
                var ordenes = _PurchaseOrderProviderService.GetAll();
                Console.WriteLine("Productos Disponibles");
                foreach (var orden in ordenes)
                {

                    Console.WriteLine($"Id: {orden.Id}\tProducto: {orden.ProductName}\tCantidad: {orden.Cantidad}\tPrecio: {orden.Precio:C}\tTotal: {orden.Total:C}\nFecha de Pedido: {orden.PurchaseDate.ToString("d")}\tEstatus: {orden.Status}\n");
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

        private void ConsultarOrdenesDeCompraEstatus()
        {
            try
            {
                var ordenes = _PurchaseOrderProviderService.GetAll();
                Console.WriteLine("Productos Disponibles");
                foreach (var orden in ordenes)
                {

                    Console.WriteLine($"Id: {orden.Id}\tProducto: {orden.ProductName}\tCantidad: {orden.Cantidad}\tPrecio: {orden.Precio:C}\tTotal: {orden.Total:C}\nFecha de Pedido: {orden.PurchaseDate.ToString("d")}\tEstatus: {orden.Status}\n");
                    Console.WriteLine("--------------------------------------------------------------------------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CambiarEstatusOrdenCompra()
        {
            Console.WriteLine("***Ordenes de Compra***");
            Console.WriteLine("¿A cual orden quieres cambiarle el estatus?");
            ConsultarOrdenesDeCompraEstatus();
            Console.Write("Ingrese el Id:" );
            var oId = IntentarObtenerInt(Console.ReadLine());
            Console.WriteLine("¿A cual estatus quieres cambiarlo?");
            int nl = 0;
            foreach (var status in Enum.GetNames<PurchaseOrderStatus>())
            {
                nl++;
                Console.WriteLine($"{nl}.{status}\n");
            }
            Console.Write("Estatus: ");
            var statusAux = Console.ReadLine();
            try
            {
                PurchaseOrderStatus newStatus;
                var didParse = Enum.TryParse(statusAux, out newStatus);
                if (didParse)
                {
                    var detail = _PurchaseOrderProviderService.ChangeStatus(oId, newStatus);
                  
                    if (newStatus == PurchaseOrderStatus.Paid)
                    {
                        var cantidad = detail.Cantidad;
                        var producto = detail.ProductId;
                        _productService.UpdateStock(cantidad,producto);
                    }
                    Console.WriteLine("Orden de compra actualizada correctamente");
                }
                else
                {
                    Console.WriteLine("El estatus solicitado no existe");
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
        private void Last7DaysOrders()
        {
            Console.WriteLine("***Reporte***");
            try
            {
                var listOrders = _reportService.Last7DaysOrders();

                foreach (var o in listOrders)
                {
                    Console.WriteLine($"Id: {o.Id}\tProducto: {o.ProductName}\tTotal: {o.Total:C}\tEstatus: {o.Status}\tFecha: {o.PurchaseDate.ToString("d")}\tProveedor: {o.ProviderName}\n");
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

        private void PurchaseOrdersChair()
        {
            Console.WriteLine("***Reporte***");
            try
            {
                var listOrders = _reportService.PurchaseOrdersChair();

                foreach (var o in listOrders)
                {
                    Console.WriteLine($"Id: {o.Id}\tProducto: {o.ProductName}\tTotal: {o.Total:C}\tEstatus: {o.Status}\tFecha: {o.PurchaseDate.ToString("d")}\tProveedor: {o.ProviderName}\n");
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

        private void PurchaseOrdersSalchichonPending()
        {
            Console.WriteLine("***Reporte***");
            try
            {
                var listOrders = _reportService.PurchaseOrdersSalchichonPending();

                foreach (var o in listOrders)
                {
                    Console.WriteLine($"Id: {o.Id}\tProducto: {o.ProductName}\tTotal: {o.Total:C}\tEstatus: {o.Status}\tFecha: {o.PurchaseDate.ToString("d")}\tProveedor: {o.ProviderName}\n");
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

        private void MorePurchasedUnits()
        {
            Console.WriteLine("***Reporte***");
            try
            {
                var listOrders = _reportService.MorePurchasedUnits();

                foreach (var o in listOrders)
                {
                    Console.WriteLine($"Id: {o.Id}\tProducto: {o.ProductName}\tCantidad: {o.Cantidad}\tTotal: {o.Total:C}\tEstatus: {o.Status}\tFecha: {o.PurchaseDate.ToString("d")}\tProveedor: {o.ProviderName}\n");
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
        #endregion

        #region Cliente
        private void AgregarProductoCarrito()
        {
            bool seguir = true;
           
           
            var product = new Product();
            try
            {
                while (seguir)
                {
                    ProductsStock();
                    Console.Write("\nAgregar Id del producto que deseas comprar: ");
                    var idP = IntentarObtenerInt(Console.ReadLine());
                    var exist = ProductL.FirstOrDefault(p => p.Id == idP);
                    if(exist is null)
                    {
                        product = _productService.GetProductC(idP);
                        totalC = totalC + product.Price;
                        ProductL.Add(product);
                        Console.WriteLine("Producto agregado al carrito");
                    }
                    else
                    {
                        Console.WriteLine("El producto ya existe en el carrito");
                    }
                    
                    Console.WriteLine("¿Desea agregar otro producto? (s/n)");
                    var opcion = Console.ReadLine();
                    seguir = opcion.ToLower().Equals("s") ? true : false;

                }
                return;
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

        private decimal ConsultarPrecio(int id)
        {
            var producto = _productService.GetProduct(id);
            return producto.Price;
        }

        private void ConsultarCarrito()
        {
            Console.WriteLine("*******Productos en el Carrito*******");
            try
            {
                if (ProductL.Any())
                {
                    foreach (var c in ProductL)
                    {
                        Console.WriteLine($"Id: {c.Id}\tProducto: {c.Name}\tPrecio: {c.Price:C}\n");
                    }
                }
                else
                {
                    Console.WriteLine("No hay productos en el carrito");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadLine();
            }
        }

        private void ConsultarCarritoComprar()
        {
            try
            {
                if (ProductL.Any())
                {
                    foreach (var c in ProductL)
                    {
                        Console.WriteLine($"Id: {c.Id}\tProducto: {c.Name}\tPrecio: {c.Price:C}\n");
                    }
                }
                else
                {
                    Console.WriteLine("No hay productos en el carrito");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void EliminarProductoCarrito()
        {
            Console.WriteLine("*******Eliminar item del carrito*******");
            try
            {
                if (ProductL.Any())
                {
                    ConsultarCarritoComprar();
                    Console.WriteLine("¿Desea eliminar un producto del carrito? (s/n)");
                    var opcion = Console.ReadLine();
                    var resp = opcion.ToLower().Equals("s") ? true : false;
                    if (resp)
                    {
                        Console.Write("Ingrese el Id del producto: ");
                        var idD = IntentarObtenerInt(Console.ReadLine());
                        var exist = ProductL.FirstOrDefault(p => p.Id == idD);
                        if (exist != null)
                        {
                            ProductL.RemoveAll(p => p.Id == idD);
                            Console.WriteLine("Se ha eliminado el producto");
                        }
                        else
                        {
                            Console.WriteLine("Id incorrecto");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Regresando al menu anterior...");
                    }
                }
                else
                {
                    Console.WriteLine("No hay productos en el carrito");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadLine();
            }
        }

        private void HacerPedidoCarrito()
        {
            Console.WriteLine("*******Comprar*******");
            try
            {
                ConsultarCarritoComprar();
                Console.WriteLine("¿Desea comprar sus productos del carrito? (s/n)");
                var opcion = Console.ReadLine();
                var resp = opcion.ToLower().Equals("s") ? true : false;
                if (resp)
                {
                    if (ProductL.Any())
                    {
                        var carrito = new CartShoppingDto(totalC);
                        _purchaseOrderCart.RegisterOrder(carrito,ProductL);
                        foreach(var p in ProductL)
                        {
                            _productService.UpdateStockPurchase(p.Id);
                        }
                        ProductL.Clear();
                    }
                    else
                    {
                        Console.WriteLine("No hay productos en el carrito");
                    }
                }
                else
                {
                    Console.WriteLine("Regresando al menu anterior....");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadLine();
            }

        }

        private void ConsultarOrdenes()
        {
            Console.WriteLine("*******Ordenes*******");
            try
            {
                var carts = _purchaseOrderCart.GetAll();
                if (carts.Any())
                {
                    foreach (var c in carts)
                    {
                        Console.WriteLine($"Id: {c.Id}\tFecha de Compra: {c.PurchaseDate}\tTotal: {c.Total:C}\n");
                        Console.WriteLine("Productos Comprados------------------------------------");
                        var products = _purchaseOrderCart.GetAllDetails(c.Id);
                        foreach (var p in products)
                        {
                            var product = _productService.GetProduct(p.ProductId);
                            Console.WriteLine($"Id: {product.Id}\tProducto: {product.Name}\tPrecio: {product.Price:C}\n");
                            Console.WriteLine("-----------------------------------------");
                        }
                       
                    }
                }
                else
                {
                    Console.WriteLine("No hay productos en el carrito");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadLine();
            }
        }
        #endregion
        private static int IntentarObtenerInt(string input)
        {
            return Int32.TryParse(input, out int posicion) ? posicion : throw new ApplicationException("No se pudo castear correctamente.");
        }

    }
}
