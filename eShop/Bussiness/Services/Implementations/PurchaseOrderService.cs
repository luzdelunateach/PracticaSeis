using System;
using System.Collections.Generic;
using System.Linq;
using Bussiness.Services.Abstractions;
using Data.Entities;
using Data.Enums;

namespace Bussiness.Services.Implementations
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private List<PurchaseOrder> _purchaseOrders = new List<PurchaseOrder>();
        public void AddPurchaseOrder(PurchaseOrder purchaseOrder) => _purchaseOrders.Add(purchaseOrder);
        public List<PurchaseOrder> GetPurchaseOrders() => _purchaseOrders;
        public PurchaseOrder ChangeStatus(int id, PurchaseOrderStatus status)
        {
            var pO = _purchaseOrders.FirstOrDefault(p => p.Id == id);
            if (pO != null)
            {
                pO.ChangeStatus(status);
                return pO;
            }
            throw new ApplicationException("No se encuentra la orden");
        }

        public void UpdateProductListStock(PurchaseOrder purchaseOrder)
        {
            /*purchaseOrder.PurchasedProducts.ForEach(pP =>
            {
                var originalProduct = 0;
                if (originalProduct != null)
                {
                    originalProduct.UpdateStock(originalProduct.Stock + pP.Stock);
                }
                else
                {
                    throw new ApplicationException("No se encuentra el producto");
                }
            });*/
        }
    }
}
