using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PurchaseOrderCartDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PurchaseOrderCartId { get; set; }
        public virtual PurchaseOrderCart PurchaseOrderCart{ get; set; }

        public PurchaseOrderCartDetail()
        {

        }

        public PurchaseOrderCartDetail(int productId, int purchaseOrderCartId)
        {
            ProductId = productId;
            PurchaseOrderCartId = purchaseOrderCartId;
        }

    }
}
