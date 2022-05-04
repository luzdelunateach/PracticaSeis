using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bussiness.Models;
using Data.Entities;

namespace Bussiness.Services.Abstractions
{
    public interface IProductService
    {
        void Delete(int id);
        Task<List<ProductDto>> GetAll();
        ProductDto GetProduct(int id);
        void RegisterProduct(ProductRegistryDto productRegistry);
        void UpdateProduct(ProductDto product);
        public void UpdateStock(int cantidad, int id);
        public List<ProductDto> GetStockProducts();
    }
}