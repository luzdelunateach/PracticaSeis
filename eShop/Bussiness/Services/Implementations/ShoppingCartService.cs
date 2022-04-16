using Bussiness.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {

        private ShoppingCart ShoppingCart = new ShoppingCart();     
        public void AddShoppingCart(Product product)
        {
            ShoppingCart.ListProducts.Add(product);
        }

        public void DeleteProductShoppingCart(int id)
        {
            //var element = ShoppingCart.FirstOrDefault(s => s.Id == id);
            //var element = ShoppingCart.Any(s => s.ListProducts.Any(s => s.Id == id));
            var element = ShoppingCart.ListProducts.Select(p => p.Id == id);
            if (element!=null)
                ShoppingCart.ListProducts.RemoveAll(x=>x.Id==id);
            else
                throw new ApplicationException("El producto no existe");
        }

        public bool ProductAlreadyExist(int id)
        {
            var element = ShoppingCart.ListProducts.Any(s => s.Id == id);
            return element;
        }

        public ShoppingCart GetShoppingCart()
        {
            return ShoppingCart;
        }
    }
}
