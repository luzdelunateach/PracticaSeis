using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
        public string PurchaseDate { get; set; }
        public decimal Total { get; set; }
        public List<ProductDto> ProductDtos { get; set; }
        /*public string NameProduct { get; set; }
        public string Price { get; set; }
        public string Brand { get; set; }*/
    }
}
