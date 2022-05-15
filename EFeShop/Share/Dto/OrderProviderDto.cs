using Share.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class OrderProviderDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime PurchaseDate { get; set; }
        public PurchaseOrderStatus? Status { get; set; }
        public string? ProviderName { get; set; }
        public int? Cantidad { get; set; }
        public string? ProductName { get; set; }
        public decimal? Precio { get; set; }
    }
}
