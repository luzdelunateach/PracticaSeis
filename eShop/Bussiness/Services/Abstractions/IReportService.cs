using System;
using System.Collections.Generic;
using Bussiness.Models;
using Data.Entities;

namespace Bussiness.Services.Abstractions
{
    public interface IReportService
    {
        public List<ProductReportDto> ReportFiveExpensiveProducts();
        public List<ProductReportDto> ReportFiveProductsorLess();
        public List<ProductReportDto> ReportProductsByBrand();
        public List<DepartmentSubdepartmentReportDto> ReportSubdepartmentProducts();
        public List<PurchaseOrder> Last7DaysOrdersWithPaidStatus();
        public List<PurchaseOrder> PurchaseOrdersChair();
        public List<PurchaseOrder> LevisPurchaseOrdersPendingOfPayment();
        public Product MorePurchasedUnitsProduct();
    }
}