using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PurchaseOrderCart
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime PurchaseDate { get; set; }
        public virtual ICollection<PurchaseOrderCartDetail> PurchaseOrderCartDetails { get; set; }
        public PurchaseOrderCart()
        {

        }
        public PurchaseOrderCart(decimal total)
        {
            Total = total;
            PurchaseDate = DateTime.Now;
        }
    }
}
