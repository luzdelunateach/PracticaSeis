using System;
using System.Collections.Generic;
using System.Linq;
using Bussiness;
using Bussiness.Models;
using Data.Entities;
using Data.Enums;

namespace eShop
{
    public partial class eShopConsole
    {

        /* #region MenuOrdenes
       private void MenuOrdenesDeCompra()
        {
            Console.Clear();
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1. Agregar orden de compra");
            Console.WriteLine("2. Ver ordenes de compra");
            Console.WriteLine("3. Cambiar estatus de la Orden");
            Console.WriteLine("4. Reporte de Ordenes de compra con estado pagado de los ultimos siete dias");
            Console.WriteLine("5. Reporte de Ordenes de compra que el producto sean sillas");
            Console.WriteLine("6. Reporte de Compras pendientes de pagar del proveedor de Levis");
            Console.WriteLine("7. Reporte de Producto mas comprado");
            Console.WriteLine("8. Regresar");

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
                    return;
            }
        }
        #endregion
        #region CRUDOrdenes
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
            Console.Write("Ingrese el Id:");
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
                        _productService.UpdateStock(cantidad, producto);
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
        */
    }
}
