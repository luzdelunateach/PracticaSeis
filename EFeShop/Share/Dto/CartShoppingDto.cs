using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class CartShoppingDto
    {
        public decimal Total { get; set; }


        public CartShoppingDto(decimal total)
        {  
            Total = total;
        }
    }
}
