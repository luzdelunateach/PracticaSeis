using Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Abstraction
{
    public interface IReportService
    {
        List<ProductDto> ProductsByBrand();
        List<ProductDto> ProductsOrderedByUnits();
        List<ProductDto> Top5ExpensiveProducts();
        public List<ProductDto> ProductsByDepartment();
        public List<OrderProviderDto> Last7DaysOrders();
        public List<OrderProviderDto> PurchaseOrdersChair();
        public List<OrderProviderDto> PurchaseOrdersSalchichonPending();
        public List<OrderProviderDto> MorePurchasedUnits();
    }
}
