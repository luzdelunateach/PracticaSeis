using System;
using System.Collections.Generic;
using System.Linq;
using Bussiness;
using Data.Entities;
using Data.Enums;

namespace eShop
{
    public partial class eShopConsole
    {
        private List<Provider> ProvidersList = TestData.GetProviders();
        private List<Product> ProductList = TestData.ProductList;
        #region MenuOrdenes
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
                    AgregarOrdenCompra();
                    break;
                case "2":
                    ConsultarOrdenesCompra();
                    break;
                case "3":
                    CambiarEstatusOrdenCompra();
                    break;
                case "4":
                    OrdenesPagadoUltimosSieteDias();
                    break;
                case "5":
                    ComprasSilla();
                    break;
                case "6":
                    ComprasPendientesLevis();
                    break;
                case "7":
                    ProductosMasComprados();
                    break;
                case "8":
                default:
                    return;
            }
        }
        #endregion
        #region CRUDOrdenes
        private void AgregarOrdenCompra()
        {
            List<Product> PurchasedProductList = new List<Product>();
            Console.WriteLine("Elige al proveedor:");
            for (int i = 0; i < ProvidersList.Count; i++)
            {
                Console.WriteLine($"No: {i+1}. {ProvidersList.ElementAt(i).Name}");
            }
            var noProveedor = IntentarObtenerInt(Console.ReadLine());
            var provider = ProvidersList.ElementAt(noProveedor - 1);

            Console.WriteLine("Elige el producto:");
            bool seguir = true;
            while (seguir)
            {
                for (int i = 0; i < ProductList.Count; i++)
                {
                    Console.WriteLine($"No: {i+1}. {ProductList.ElementAt(i).Name } \tPrecio ${ ProductList.ElementAt(i).Price }");
                }
                var noProduct = IntentarObtenerInt(Console.ReadLine());
                var product = ProductList.ElementAt(noProduct - 1);
                Console.WriteLine($"\n¿Cuantos {product.Name} deseas comprar?");
                var cantidad = IntentarObtenerInt(Console.ReadLine());
                var auxProduct = new Product(product.Name, product.Price, product.Description, product.Brand, product.Sku, product.Id);
                auxProduct.UpdateStock(cantidad);
                PurchasedProductList.Add(auxProduct);
                Console.WriteLine("El producto se ha agregado correctamento\n\n");
                Console.WriteLine("¿Desea agregar otro producto? (s/n)");
                var opcion = Console.ReadLine();
                seguir = opcion.ToLower().Equals("s") ? true : false;
            }
            PurchaseOrder purchase = new PurchaseOrder(provider, PurchasedProductList, DateTime.Now);
            _purchaseOrderService.AddPurchaseOrder(purchase);
            Console.WriteLine("Se ha registrado la orden de compra agregada correctamente");
        }

        private void ConsultarOrdenesCompra()
        {
            var ordenesList = _purchaseOrderService.GetPurchaseOrders();
            ordenesList.ForEach(ol =>
            {
                Console.WriteLine($"Id:{ol.Id} \tProveedor: {ol.Provider.Name} \tCant.Artículos: {ol.PurchasedProducts.Sum(p => p.Stock)} \tTotal: {ol.Total:C} \tEstatus: {ol.Status}");
                ol.PurchasedProducts.ForEach(p =>
                {
                    Console.WriteLine($"\nProducto: {p.Name} \tPrecio: {p.Price:C}\n");
                });
            });
        }

        private void CambiarEstatusOrdenCompra()
        {
            Console.WriteLine("Ingresa el Id, de la orden a cambiar el estatus: ");
            var poId = IntentarObtenerInt(Console.ReadLine());

            Console.WriteLine("Selecciona el numero de estatus al que quieres cambiar la orden");
            foreach (var statusE in Enum.GetNames<PurchaseOrderStatus>())
            {
                Console.WriteLine(statusE);
            }
            var statusAux = Console.ReadLine();
            PurchaseOrderStatus newStatus;
            var didParse = Enum.TryParse(statusAux, out newStatus);
            if (didParse)
            {
                var po = _purchaseOrderService.ChangeStatus(poId, newStatus);
                if (newStatus == PurchaseOrderStatus.Paid)
                {
                    ActualizarStock(po);
                }
                Console.WriteLine("Orden de compra ha sido actualizada correctamente");
            }
            else
            {
                Console.WriteLine("El estatus solicitado no existe");
            }
        }

        private void ActualizarStock(PurchaseOrder order)
        {
            _purchaseOrderService.UpdateProductListStock(order);
            Console.WriteLine("El stock se ha actualizado correctamente");
        }

        
        private void OrdenesPagadoUltimosSieteDias()
        {
            var orderList = _reportService.ReportLastSevenDays();
            if (orderList.Any())
            {
                orderList.ForEach(ol =>
                {
                    Console.WriteLine($"Id: {ol.Id} \tProveedor: {ol.Provider.Name} \tArticulos: {ol.PurchasedProducts.Sum(p => p.Stock)} \tTotal: {ol.Total:C} \tEstatus: {ol.Status}");
                });
            }
            else
            {
                Console.WriteLine("No se encontraron ordenes de compra");
            }
        }
        
        private void ComprasSilla()
        {
            var orderList = _reportService.ReportPurchaseOrdersChair();
            if (orderList.Any())
            {
                orderList.ForEach(ol =>
                {
                    Console.WriteLine($"Id: {ol.Id} \tProveedor: {ol.Provider.Name} \tArtiulos: {ol.PurchasedProducts.Sum(p => p.Stock)} \tTotal: {ol.Total:C} \tEstatus: {ol.Status}");
                });
            }
            else
            {
                Console.WriteLine("No se encontraron las ordenes de compra");
            }
        }
      
        private void ComprasPendientesLevis()
        {
            var orderList = _reportService.ReportLevisPurchaseOrders();
            if (orderList.Any())
            {
                orderList.ForEach(ol =>
                {
                    Console.WriteLine($"Id: {ol.Id} \tProveedor: {ol.Provider.Name} \tCant.Artículos: {ol.PurchasedProducts.Sum(p => p.Stock)} \tTotal: {ol.Total:C} \tEstatus: {ol.Status}");
                });
            }
            else
            {
                Console.WriteLine("No se encontraron las ordenes de compra");
            }
        }
        private void ProductosMasComprados()
        {
            var product = _reportService.ReportMorePurchasedProduct();
            if (product != null)
                Console.WriteLine(product.ToString());
            else
                Console.WriteLine("No se encontra el producto");
        }
        #endregion
    }
}
