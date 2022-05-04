using Bussiness.Models;
using Data.Entities;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstractions
{
    public interface IPurchaseOrderProviderService
    {
        void RegisterOrder(OrderProviderRegestryDto order);
        public List<OrderProviderDto> GetAll();
        public PurchaseOrderProviderDetail ChangeStatus(int purchaseId, PurchaseOrderStatus status);
        
    }
}
