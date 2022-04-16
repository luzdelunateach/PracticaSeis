using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstractions
{
    public interface IShoppingCartService
    {
        public ShoppingCart GetShoppingCart();
        public void AddShoppingCart(Product product);
        public void DeleteProductShoppingCart(int id);
        public bool ProductAlreadyExist(int id);
    }
}
