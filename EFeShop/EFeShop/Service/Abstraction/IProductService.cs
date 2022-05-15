using Model.Entities;
using Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Abstraction
{
    public interface IProductService
    {
        void Delete(int id);
        List<ProductDto> GetAll();
        ProductDto GetProduct(int id);
        Product GetProductC(int id);
        void RegisterProduct(ProductRegistryDto productRegistry);
        void UpdateProduct(ProductDto product);
        public void UpdateStock(int cantidad, int id);
        public List<ProductDto> GetStockProducts();
        public void UpdateStockPurchase(int id);
    }
}
