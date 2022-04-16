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


        public PurchaseOrder ChangeStatus(int purchaseOrderId, PurchaseOrderStatus status)
        {
            var p = _purchaseOrders.FirstOrDefault(x => x.Id == purchaseOrderId);

            if (p != null)
            {
                p.ChangeStatus(status);
                return p;
            }

            throw new ApplicationException("No se encuentra la orden solicitada.");
        }

        public void UpdateOriginalStock(PurchaseOrder purchaseOrder)
        {
            purchaseOrder.PurchasedProducts.ForEach(purProd =>
            {
                var originalProduct = TestData.ProductList.Where(x => x.Id == purProd.Id).FirstOrDefault();
                if (originalProduct != null)
                {
                    originalProduct.UpdateStock(originalProduct.Stock + purProd.Stock);
                }
                else
                {
                    throw new ApplicationException("No se encuentra el producto");
                }
            });
        }
    }
}
