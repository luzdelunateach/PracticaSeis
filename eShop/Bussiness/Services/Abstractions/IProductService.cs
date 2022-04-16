﻿using System;
using System.Collections.Generic;
using Data.Entities;

namespace Bussiness.Services.Abstractions
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public List<Product> GetProductStock();
        public Product GetProduct(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
    }
}
