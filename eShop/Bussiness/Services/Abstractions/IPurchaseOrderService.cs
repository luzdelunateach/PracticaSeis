﻿using System;
using System.Collections.Generic;
using Data.Entities;
using Data.Enums;

namespace Bussiness.Services.Abstractions
{
    public interface IPurchaseOrderService
    {
        public void AddPurchaseOrder(PurchaseOrder purchaseOrder);
        public List<PurchaseOrder> GetPurchaseOrders();
        public PurchaseOrder ChangeStatus(int purchaseOrderId, PurchaseOrderStatus status);
        public void UpdateOriginalStock(PurchaseOrder purchaseOrder);
    }
}
