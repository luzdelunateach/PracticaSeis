using System;
using System.Collections.Generic;
using System.Linq;
using Bussiness.Services.Abstractions;
using Data.Entities;

namespace Bussiness.Services.Implementations
{
    public class ProductService : IProductService
    {
        private List<Product> ProductList = TestData.ProductList;

        public List<Product> GetProducts()
        {
            return ProductList;
        }

        public Product GetProduct(int id)
        {
           
            return ProductList.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductStock()
        {
            var element = ProductList.Where(p => p.Stock > 0).ToList();
            
            return element;
        }

        public void AddProduct(Product product)
        {
            ProductList.Add(product);
        }
        
        public void UpdateProduct(Product product)
        {
            var element = ProductList.FirstOrDefault(p => p.Id == product.Id);
            if (element != null)
            {
                var index = ProductList.IndexOf(element);
                ProductList[index] = product;
            }
            else
            {
                throw new ApplicationException("El producto no fue encontrado");
            }
        }

        public void DeleteProduct(int id)
        {
            
            var element = ProductList.FirstOrDefault(p => p.Id == id);
            if (element != null)
                ProductList.Remove(element);
            else
                throw new ApplicationException("El producto no fue encontrado");
        }
    }
}
