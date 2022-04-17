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
        private List<Product> ProductList = TestData.ProductList;
        private List<Department> DepartmentList = TestData.DepartmentList;
        private PurchaseOrderService purchaseOrderService = new PurchaseOrderService();
        

        public List<ProductReportDto> ReportFiveExpensiveProducts()
        {
            return ProductList
                .OrderByDescending(c => c.Price)
                .Take(5)
                .Select(c => new ProductReportDto
                {
                    Name = c.Name,
                    Price = c.Price
                }).ToList();
        }

        public List<ProductReportDto> ReportFiveProductsorLess()
        {
            return ProductList
                .Where(prod => prod.Stock < 5)
                .OrderBy(prod => prod.Price)
                .Select(c => new ProductReportDto
                {
                    Name = c.Name,
                    Price = c.Price,
                    Stock = c.Stock
                }).ToList();
        }

        public List<ProductReportDto> ReportProductsByBrand()
        {
            return ProductList
                .OrderBy(c => c.Brand)
                .ThenBy(c => c.Name)
                .Select(c => new ProductReportDto
                {
                    Name = c.Name,
                    Brand = c.Brand
                }).ToList();
        }

        public List<DepartmentSubdepartmentReportDto> ReportSubdepartmentProducts()
        {
            return DepartmentList
                .GroupBy(d => d.Name)
                .Select(d => new DepartmentSubdepartmentReportDto
                {
                    Department = d.Key,
                    Subdepartaments = DepartmentList.Where(dp => dp.Name == d.Key).First().Subdeparments
                        .GroupBy(s => s.Name)
                        .Select(s => new SubdepartmentReportDto
                        {
                            Subdepartment = s.Key,
                            Productos = ProductList.Where(p => p.Subdepartment.Name == s.Key)
                                .Select(pd => new ProductReportDto {
                                    Name = pd.Name,
                                    Price = pd.Price
                                }).ToList()
                        }).ToList()
                }).ToList();
        }

        public List<PurchaseOrder> ReportLastSevenDays()
        {
            var purchaseOrders = purchaseOrderService.GetPurchaseOrders();
            return purchaseOrders
                .Where(pOL => pOL.PurchaseDate >= DateTime.Now.AddDays(-7) && pOL.Status == PurchaseOrderStatus.Paid)
                .ToList();
        }

        public List<PurchaseOrder> ReportPurchaseOrdersChair()
        {
            var purchaseOrders = purchaseOrderService.GetPurchaseOrders();
            return purchaseOrders
                .Where(pOL => pOL.PurchasedProducts.Any(p => p.Name.Equals("Silla")))
                .ToList();
        }

        public List<PurchaseOrder> ReportLevisPurchaseOrders()
        {
            var purchaseOrders = purchaseOrderService.GetPurchaseOrders();
            return purchaseOrders
                .Where(pOL => pOL.Provider.Name.Equals("Levis") && pOL.Status != PurchaseOrderStatus.Paid)
                .ToList();
        }

        public Product ReportMorePurchasedProduct()
        {
            var purchaseOrders = purchaseOrderService.GetPurchaseOrders();

            return purchaseOrders.Where(pOL => pOL.Status == PurchaseOrderStatus.Paid)
                .SelectMany(x => x.PurchasedProducts)
                .GroupBy(g => g.Id)
                .Select(g => new { g.Key, Product = g.First(), Sum = g.Sum(d => d.Stock) })
                .OrderByDescending(c => c.Sum)
                .FirstOrDefault()?.Product;
        }
    }
}
