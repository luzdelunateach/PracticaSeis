using System;
using System.Collections.Generic;
using System.Linq;
using Bussiness.Models;
using Bussiness.Services.Abstractions;
using Data.Entities;

namespace Bussiness.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public void RegisterProduct(ProductRegistryDto productRegistry)
        {
            var subdeparment = _context.Subdepartments.FirstOrDefault(s => s.Id == productRegistry.SubdepartmentId);
            try
            {
                if (subdeparment is null)
                    throw new ArgumentNullException("El subdepartamento no existe.");

                var product = new Product(productRegistry.Name, productRegistry.Stock, productRegistry.Price, productRegistry.Sku, productRegistry.Description, productRegistry.Brand, subdeparment);

                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ProductDto> GetAll()
        {
            var products = _context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                Price = p.Price,
                Sku = p.Sku,
                Description = p.Description,
                Brand = p.Brand,
                SudepartmentName = p.Subdepartment.Name,
                DepartmentName = p.Subdepartment.Department.Name
            }).ToList();

            if (!products.Any())
                throw new Exception("No hay productos.");

            return products;
        }

        public List<ProductDto> GetStockProducts()
        {
            var products = _context.Products
                .Where(p => p.Stock > 0)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Stock = p.Stock,
                    Price = p.Price,
                    Sku = p.Sku,
                    Description = p.Description,
                    Brand = p.Brand,
                    SudepartmentName = p.Subdepartment.Name,
                    DepartmentName = p.Subdepartment.Department.Name
                }).ToList();
            if (!products.Any())
                throw new Exception("No hay productos.");

            return products;
        }
        public ProductDto GetProduct(int id)
        {
            var product = _context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                Price = p.Price,
                Sku = p.Sku,
                Description = p.Description,
                Brand = p.Brand,
                SudepartmentName = p.Subdepartment.Name,
                DepartmentName = p.Subdepartment.Department.Name
            }).FirstOrDefault(s => s.Id == id);
            if (product is null)
                throw new Exception("El producto no existe.");
            return product;
        }

        public void UpdateProduct(ProductDto product)
        {
            var products = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            try
            {
                products.Name = product.Name;
                products.Price = product.Price;
                products.Description = product.Description;
                products.Brand = product.Brand;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateStock(int cantidad, int id)
        {
            var products = _context.Products.FirstOrDefault(p => p.Id == id);
            try
            {
                products.Stock = products.Stock + cantidad;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null)
                throw new Exception($"No existe ningun producto con el Id: {id}");

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}