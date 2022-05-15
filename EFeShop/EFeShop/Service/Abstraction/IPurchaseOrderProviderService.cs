using Model.Entities;
using Share.Dto;
using Share.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Abstraction
{
    public interface IPurchaseOrderProviderService
    {
        void RegisterOrder(OrderProviderRegestryDto order);
        public List<OrderProviderDto> GetAll();
        public PurchaseOrderProviderDetail ChangeStatus(int purchaseId, PurchaseOrderStatus status);
        
    }
}
