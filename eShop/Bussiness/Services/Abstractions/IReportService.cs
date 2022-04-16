using System;
using System.Collections.Generic;
using Bussiness.Models;
using Data.Entities;

namespace Bussiness.Services.Abstractions
{
    public interface IReportService
    {
        public List<ProductReportDto> Top5ExpensiveProductsOrderedByPrice();
        public List<ProductReportDto> Products5orLessUnitsOrderedByUnits();
        public List<BrandProductReportDto> ProductsByBrandOrderedByProductName();
        public List<DepartmentSubdepartmentProductReportDto> GroupDepartmentGroupSubdepartmentProducts();
        public List<PurchaseOrder> Last7DaysOrdersWithPaidStatus();
        public List<PurchaseOrder> PurchaseOrdersChair();
        public List<PurchaseOrder> LevisPurchaseOrdersPendingOfPayment();
        public Product MorePurchasedUnitsProduct();
    }
}