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
        private void MenuOrdenesDeCompra()
        {
            Console.Clear();
            Console.WriteLine("Elige una opción");
            Console.WriteLine("1. Agregar orden de compra");
            Console.WriteLine("2. Ver ordenes de compra");
            Console.WriteLine("3. Cambiar estatus");
            Console.WriteLine("4. Reporte: Ordenes de compra con estado pagado de los últimos 7 días");
            Console.WriteLine("5. Reporte: Ordenes de compra que abastecieron la silla");
            Console.WriteLine("6. Reporte: Compras pendientes de pagar del proveedor Levis");
            Console.WriteLine("7. Producto con unidades más compradas");
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
                    OrdenesConEstadoPagadoUltimos7Dias();
                    break;
                case "5":
                    ComprasAbastecieronSilla();
                    break;
                case "6":
                    ComprasPendientesDePagoLevis();
                    break;
                case "7":
                    ProductoUnidadesMasCompradas();
                    break;
                case "8":
                default:
                    return;
            }
        }

        private void AddPurchaseOrder()
        {
            List<Product> PurchasedProductList = new List<Product>();
            Console.WriteLine("Elige al proveedor");
            for (int i = 0; i < ProvidersList.Count; i++)
            {
                Console.WriteLine($"{i+1}. { ProvidersList.ElementAt(i).Name }");
            }
            var proveedorPosition = IntentarObtenerInt(Console.ReadLine());
            var provider = ProvidersList.ElementAt(proveedorPosition - 1);

            Console.WriteLine("Elige el producto");
            bool seguir = true;
            while (seguir)
            {
                for (int i = 0; i < ProductList.Count; i++)
                {
                    Console.WriteLine($"{i+1}. { ProductList.ElementAt(i).Name } Precio ${ ProductList.ElementAt(i).Price }");
                }
                var productPosition = IntentarObtenerInt(Console.ReadLine());
                var product = ProductList.ElementAt(productPosition - 1);


                Console.WriteLine($"\n¿Que cantidad de {product.Name}(s) deseas comprar?");
                var cantidad = IntentarObtenerInt(Console.ReadLine());

                var pProduct = new Product(product.Name, product.Price, product.Description, product.Brand, product.Sku, product.Id);
                pProduct.UpdateStock(cantidad);
                PurchasedProductList.Add(pProduct);
                Console.WriteLine("Producto agregado correctamento\n\n");


                Console.WriteLine("¿Desea agregar otro producto? (s/n)");
                var opcion = Console.ReadLine();
                
                seguir = opcion.ToLower().Equals("s") ? true : false;
            }

            PurchaseOrder purchase = new PurchaseOrder(provider, PurchasedProductList, DateTime.Now);
            _purchaseOrderService.AddPurchaseOrder(purchase);
            Console.WriteLine("Orden de Compra agregada correctamente");
        }

        private void ConsultarOrdenesDeCompra()
        {
            // :C -> Es para darle fomrato al tipo de dato (C = Currency)
            var ordenesList = _purchaseOrderService.GetPurchaseOrders();
            ordenesList.ForEach(o =>
            {
                Console.WriteLine($"OrderId:{o.Id}      Proveedor: {o.Provider.Name}    Cant.Artículos: {o.PurchasedProducts.Sum(x => x.Stock)}     Total: {o.Total:C}      Estatus: {o.Status.ToString().ToUpper()}");
                o.PurchasedProducts.ForEach(p =>
                {
                    Console.WriteLine($"\tProducto: {p.Name}    Precio: {p.Price:C}\n");
                });
            });
        }

        private void CambiarEstatusOrdenCompra()
        {
            Console.WriteLine("¿A que órden quieres cambiarle el estatus?");
            var poId = IntentarObtenerInt(Console.ReadLine());

            Console.WriteLine("¿A que estatus quieres cambiarlo?");
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
                Console.WriteLine("Orden de compra actualizada correctamente");
            }
            else
            {
                Console.WriteLine("El estatus solicitado no existe");
            }
        }

        private void ActualizarStock(PurchaseOrder order)
        {
            _purchaseOrderService.UpdateOriginalStock(order);
            Console.WriteLine("El stock ha sido modificado");
        }

        
        private void OrdenesConEstadoPagadoUltimos7Dias()
        {
            var list = _reportService.Last7DaysOrdersWithPaidStatus();
            if (list.Any())
            {
                list.ForEach(o =>
                {
                    Console.WriteLine($"Id:{o.Id}      Proveedor: {o.Provider.Name}    Articulos: {o.PurchasedProducts.Sum(x => x.Stock)}     Total: {o.Total:C}      Estatus: {o.Status.ToString().ToUpper()}");
                });
            }
            else
            {
                Console.WriteLine("No se encontraron las ordenes de compra.");
            }
        }
        
        private void ComprasAbastecieronSilla()
        {
            var list = _reportService.PurchaseOrdersChair();
            if (list.Any())
            {
                list.ForEach(c =>
                {
                    Console.WriteLine($"Id:{c.Id}      Proveedor: {c.Provider.Name}    Artiulos: {c.PurchasedProducts.Sum(x => x.Stock)}     Total: {c.Total:C}      Estatus: {c.Status.ToString().ToUpper()}");
                });
            }
            else
            {
                Console.WriteLine("No se encontraron las ordenes de compra.");
            }
        }
      
        private void ComprasPendientesDePagoLevis()
        {
            var list = _reportService.LevisPurchaseOrdersPendingOfPayment();
            if (list.Any())
            {
                list.ForEach(o =>
                {
                    Console.WriteLine($"Id:{o.Id}      Proveedor: {o.Provider.Name}    Cant.Artículos: {o.PurchasedProducts.Sum(x => x.Stock)}     Total: {o.Total:C}      Estatus: {o.Status.ToString().ToUpper()}");
                });
            }
            else
            {
                Console.WriteLine("No se encontraron las ordenes de compra");
            }
        }
        private void ProductoUnidadesMasCompradas()
        {
            var producto = _reportService.MorePurchasedUnitsProduct();
            if (producto != null)
                Console.WriteLine(producto.ToString());
            else
                Console.WriteLine("No se encontró el producto.");
        }
    }
}
