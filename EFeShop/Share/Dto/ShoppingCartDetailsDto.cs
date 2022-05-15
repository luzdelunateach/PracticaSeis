using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class ShoppingCartDetailsDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PurchaseOrderCartId { get; set; }
    }
}
