using EFeShop.Service.Abstraction;
using Model;
using Share.Dto;
using Share.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Implementation
{
    public class ReportService:IReportService
    {
        private readonly AppDbContext context = new AppDbContext();

        public List<ProductDto> Top5ExpensiveProducts()
        {
            var report = context.Products
                .OrderByDescending(p => p.Price)
                .Take(5)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToList();
            if (!report.Any())
                throw new Exception("No hay productos.");

            return report;
        }
        public List<ProductDto> ProductsOrderedByUnits()
        {
            var report = context.Products
                .Where(p => p.Stock < 5)
                .OrderBy(p => p.Price)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToList();
            if (!report.Any())
                throw new Exception("No hay productos.");

            return report;
        }

        /*public List<BrandReportDto> ProductsByBrand()
        {
            var report = context.Products
                .OrderBy(p => p.Name)
                .GroupBy(p => p.Brand)
                .Select(p => new BrandReportDto
                {
                    Brand = p.Key,
                    Productos = p.Select(b => new ProductDto { Name = b.Name, Price = b.Price }).ToList()
                }).ToList();
            if (!report.Any())
                throw new Exception("No hay productos.");

            return report;
        }*/

        public List<ProductDto> ProductsByBrand()
        {
            var report = context.Products
                .OrderBy(p => p.Brand)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Brand = p.Brand,
                    Price = p.Price
                }).ToList();
            if (!report.Any())
                throw new Exception("No hay productos.");

            return report;
        }

        public List<ProductDto> ProductsByDepartment()
        {
            var report = context.Products
                .OrderBy(p => p.Subdepartment.Department.Id)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Brand = p.Brand,
                    Price = p.Price,
                    SudepartmentName=p.Subdepartment.Name,
                    DepartmentName=p.Subdepartment.Department.Name
                }).ToList();
            if (!report.Any())
                throw new Exception("No hay productos.");

            return report;
        }

        public List<OrderProviderDto> Last7DaysOrders()
        {
            var orders = context.PurchaseOrderProviders
                .Where(x => x.PurchaseDate >= DateTime.Now.AddDays(-7) && x.Status == PurchaseOrderStatus.Paid)
                .Select(x=>new OrderProviderDto {
                    Id = x.Id,
                    Total=x.Total,
                    PurchaseDate=x.PurchaseDate,
                    Status=x.Status,
                    ProductName=x.PurchaseOrderProviderDetails.FirstOrDefault(p=>p.PurchaseOrderProviderId==x.Id).Product.Name,
                    ProviderName=x.Provider.Name
                }) .ToList();
            if (!orders.Any())
                throw new Exception("No hay ordenes.");

            return orders;
        }

        public List<OrderProviderDto> PurchaseOrdersChair()
        {
            var orders = context.PurchaseOrderProviders
                .Select(x => new OrderProviderDto
                {
                    Id = x.Id,
                    Total = x.Total,
                    PurchaseDate = x.PurchaseDate,
                    Status = x.Status,
                    ProductName = x.PurchaseOrderProviderDetails.FirstOrDefault(p => p.PurchaseOrderProviderId == x.Id).Product.Name,
                    ProviderName = x.Provider.Name
                }).Where(p=>p.ProductName.Equals("Silla"))
                .ToList();
            if (!orders.Any())
                throw new Exception("No hay ordenes.");

            return orders;
        }

        public List<OrderProviderDto> PurchaseOrdersSalchichonPending()
        {
            var orders = context.PurchaseOrderProviders
                .Select(x => new OrderProviderDto
                {
                    Id = x.Id,
                    Total = x.Total,
                    PurchaseDate = x.PurchaseDate,
                    Status = x.Status,
                    ProductName = x.PurchaseOrderProviderDetails.FirstOrDefault(p => p.PurchaseOrderProviderId == x.Id).Product.Name,
                    ProviderName = x.Provider.Name
                }).Where(p => p.ProductName.Equals("salchichon") && p.Status==PurchaseOrderStatus.Pending)
                .ToList();
            if (!orders.Any())
                throw new Exception("No hay ordenes.");

            return orders;
        }

        public List<OrderProviderDto> MorePurchasedUnits()
        {
            var orders = context.PurchaseOrderProviders
                .OrderByDescending(x=>x.PurchaseOrderProviderDetails.FirstOrDefault(p => p.PurchaseOrderProviderId == x.Id).Cantidad)
                .Select(x => new OrderProviderDto
                {
                    Id = x.Id,
                    Total = x.Total,
                    PurchaseDate = x.PurchaseDate,
                    Status = x.Status,
                    ProductName = x.PurchaseOrderProviderDetails.FirstOrDefault(p => p.PurchaseOrderProviderId == x.Id).Product.Name,
                    Cantidad = x.PurchaseOrderProviderDetails.FirstOrDefault(p => p.PurchaseOrderProviderId == x.Id).Cantidad,
                    ProviderName = x.Provider.Name
                }).Take(1)
                .ToList();
            if (!orders.Any())
                throw new Exception("No hay ordenes.");

            return orders;
        }
    }
}
