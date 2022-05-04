using System;
using System.Collections.Generic;
using System.Linq;
using Data.Enums;

namespace Data.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; private set; }
        public decimal Total { get; private set; }
        public DateTime PurchaseDate { get; private set; } = DateTime.Now;
        public Provider Provider { get; set; }
        public List<Product> PurchasedProducts { get; set; }
        public PurchaseOrderStatus Status { get; set; }


        public PurchaseOrder(Provider provider, List<Product> purchasedProducts, DateTime? purchaseDate = null)
        {
            if (provider == null)
                throw new ArgumentNullException("El proveedor no puede ser vacío.");

            if (purchasedProducts == null || !purchasedProducts.Any())
                throw new ArgumentNullException("Hay que agregar productos a la orden");

            Status = PurchaseOrderStatus.Pending;
            Total = purchasedProducts.Sum(p => p.Price * p.Stock);
            Provider = provider;
            PurchasedProducts = purchasedProducts;
            PurchaseDate = purchaseDate ?? DateTime.Now;
        }

        public void ChangeStatus(PurchaseOrderStatus status)
        {
            Status = status;
        }
    }
}
