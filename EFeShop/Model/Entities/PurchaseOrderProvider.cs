using Share.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PurchaseOrderProvider
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime PurchaseDate { get; set; }
        public PurchaseOrderStatus? Status { get; set; }
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<PurchaseOrderProviderDetail> PurchaseOrderProviderDetails { get; set; }

        public PurchaseOrderProvider()
        {

        }
        public PurchaseOrderProvider(decimal total, int idProvider)
        {
            Total = total;
            PurchaseDate = DateTime.Now;
            Status = PurchaseOrderStatus.Pending;
            ProviderId = idProvider;
        }
    }
}
