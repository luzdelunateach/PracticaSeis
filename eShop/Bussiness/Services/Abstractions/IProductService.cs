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

        Task<Product> AddAsync(Product product);

        Task<bool> DeleteAsync(int id);

        Task<Product> EditAsync(ProductDto product);

        Task<Product> GetAsync(int id);
        ProductDto GetProduct(int id);
        //void RegisterProduct(ProductRegistryDto productRegistry);
        void UpdateProduct(ProductDto product);
        public void UpdateStock(int cantidad, int id);
        public List<ProductDto> GetStockProducts();
    }
}