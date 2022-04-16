using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Request
    {
        public int Id { get; private set; }
        public DateTime PurchaseDate { get; private set; } = DateTime.Now;
        public ShoppingCart ShoppingCarts { get; private set; }
        public decimal Total { get; private set; }

        private int _idSeed = 1;
        public Request(int? id, ShoppingCart shoppingCarts, DateTime? purchaseDate)
        {
            if (shoppingCarts == null)
                throw new ApplicationException("Error, no existe el carrito de compras");

            Id = _idSeed++;
            ShoppingCarts = shoppingCarts;
            Total = shoppingCarts.ListProducts.Sum(s => s.Price);
            PurchaseDate = purchaseDate ?? DateTime.Now;
        }

    }
}
