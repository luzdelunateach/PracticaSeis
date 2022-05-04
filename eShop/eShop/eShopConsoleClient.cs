using Bussiness;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        #region MenuCliente
        private void MenuCliente()
        {
            Console.Clear();
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1. Agregar productos al carrito");
            Console.WriteLine("2. Ver carrito");
            Console.WriteLine("3. Eliminar producto del carrito");
            Console.WriteLine("4. Hacer Pedido");
            Console.WriteLine("5. Ver Pedido");
            Console.WriteLine("6. Regresar");

            /*switch (Console.ReadLine())
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
                    HacerPedido();
                    break;
                case "5":
                    ConsultarPedido();
                    break;
                case "6":
                default:
                    return;
            }*/
           
        }
        #endregion
        #region CRUD
        /*private void AgregarProductoCarrito()
        {
            List<Product> listShopProducts = new List<Product>();
            bool seguir = true;
            while(seguir)
            {
                    ConsultarProductosStock();
                    Console.WriteLine("\nAgrega el Id del Producto, que deseas agregar");
                    var idP = IntentarObtenerInt(Console.ReadLine());
                    var exist = _shoppingCartService.GetShoppingCart().ListProducts.Any(p=>p.Id==idP);
                    if (exist)
                    {
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("El producto ya se ha agregado, elige otro\n");
                    }
                    else
                    {
                        Product product = _productService.GetProduct(idP);
                        _shoppingCartService.GetShoppingCart().ListProducts.Add(product);
                    }
                    Console.WriteLine("¿Desea agregar otro producto? (s/n)");
                    var opcion = Console.ReadLine();
                    seguir = opcion.ToLower().Equals("s") ? true : false;
            }
        }

        private void ConsultarCarrito()
        {
            var list = _shoppingCartService.GetShoppingCart().ListProducts;
            list.ForEach(s =>
            {
                   Console.WriteLine($"Id: {s.Id} \tProducto: {s.Name} Precio: {s.Price:C}\n");
            });
        }
        private void EliminarProductoCarrito()
        {
            ConsultarCarrito();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\nSelecciona el No. del producto que deseas eliminar");
            Console.WriteLine("Id:");
            var id = IntentarObtenerInt(Console.ReadLine());

            try
            {
                _shoppingCartService.DeleteProductShoppingCart(id);
                Console.WriteLine("Producto eliminado del carrito");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void QuitarProductosStock()
        {
            var list = _shoppingCartService.GetShoppingCart().ListProducts;
            int status = 0;
            list.ForEach(q =>
            {
                    Product product = _productService.GetProduct(q.Id);
                    status = product.Stock - 1;
                    product.UpdateStockShop(status);
              
            });
            
        }
        private void HacerPedido()
        {
            var seguir = false;
            var exist = _shoppingCartService.GetShoppingCart();
            if (exist != null)
            {
                ConsultarCarrito();
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("¿Desea proceder con el pedido? (s/n)");
                var opcion = Console.ReadLine();
                seguir = opcion.ToLower().Equals("s") ? true : false;
                if (seguir)
                {
                    var cart = _shoppingCartService.GetShoppingCart();
                    Request request = new Request(null,cart,null);
                    _requestService.AddRequest(request);
                    QuitarProductosStock();
                    Console.WriteLine("Realizando la compra...");
                }  
            }
            else
                Console.WriteLine("No hay productos en el carrito");
        }

        private void ConsultarPedido()
        {
            var list = _requestService.GetRequest();
            list.ForEach(p =>
            {
                Console.WriteLine($"No de Pedido:{p.Id}\t Fecha:{p.PurchaseDate}\t Total:{p.Total:C}");
                p.ShoppingCarts.ListProducts.ForEach(p =>
                {
                    Console.WriteLine($"Id: {p.Id} \tProducto: {p.Name} \tPrecio: {p.Price:C}\n");
                });
            });
        }*/
        #endregion
    }
}
