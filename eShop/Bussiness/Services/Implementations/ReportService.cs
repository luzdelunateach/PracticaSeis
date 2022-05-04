using System;
using System.Collections.Generic;
using System.Linq;
using Bussiness.Models;
using Bussiness.Services.Abstractions;
using Data.Entities;
using Data.Enums;

namespace Bussiness.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public List<OrderProviderDto> Last7DaysOrders()
        {
            throw new NotImplementedException();
        }

        public List<OrderProviderDto> MorePurchasedUnits()
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> ProductsByBrand()
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> ProductsByDepartment()
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> ProductsOrderedByUnits()
        {
            throw new NotImplementedException();
        }

        public List<OrderProviderDto> PurchaseOrdersChair()
        {
            throw new NotImplementedException();
        }

        public List<OrderProviderDto> PurchaseOrdersSalchichonPending()
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> Top5ExpensiveProducts()
        {
            throw new NotImplementedException();
        }
    }
}
