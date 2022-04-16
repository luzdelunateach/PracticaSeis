using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ShoppingCart
    {
        public int Id { get; private set; }
        public List<Product> ListProducts { get; set; }
       
        private int _idSeed = 1;

        public ShoppingCart() {
            Id = _idSeed++;
            ListProducts = new List<Product>();
        }
        public ShoppingCart(int? id, List<Product>? listProducts)
        {
            if ( listProducts == null || !listProducts.Any())
                throw new InvalidOperationException("No hay listas de Productos");

            Id = _idSeed++;
            ListProducts = listProducts;
        }
    }
}
