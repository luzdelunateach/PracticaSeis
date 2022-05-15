using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PurchaseOrderProviderDetail
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int PurchaseOrderProviderId { get; set; }
        public int ProductId { get; set; }
        public virtual PurchaseOrderProvider PurchaseOrderProvider { get; set; }
        public virtual Product Product { get; set; }

        public PurchaseOrderProviderDetail()
        {

        }

        public PurchaseOrderProviderDetail(int purchaseOrderProviderId, int productId, int cantidad)
        {
            PurchaseOrderProviderId = purchaseOrderProviderId;
            ProductId = productId;
            Cantidad = cantidad;
        }
    }
}
