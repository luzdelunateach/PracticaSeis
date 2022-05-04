using System;
using System.Collections.Generic;
using Bussiness.Models;
using Data.Entities;

namespace Bussiness.Services.Abstractions
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