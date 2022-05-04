using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class CartShoppingDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public CartShoppingDto(int id, decimal price)
        {
            Id = id;
            Price = price;
            
        }
    }
}
