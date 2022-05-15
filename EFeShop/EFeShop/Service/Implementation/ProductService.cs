using EFeShop.Service.Abstraction;
using Model;
using Model.Entities;
using Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Implementation
{
    public class ProductService:IProductService
    {
        private readonly AppDbContext context = new AppDbContext();

        public void RegisterProduct(ProductRegistryDto productRegistry)
        {
            var subdeparment = context.Subdepartments.FirstOrDefault(s=>s.Id==productRegistry.SubdepartmentId);
            try
            {
                if (subdeparment is null)
                throw new ArgumentNullException("El subdepartamento no existe.");

                var product = new Product(productRegistry.Name, productRegistry.Stock, productRegistry.Price, productRegistry.Sku, productRegistry.Description, productRegistry.Brand, subdeparment);
            
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ProductDto> GetAll()
        {
            var products = context.Products.Select(p => new ProductDto
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
            var products = context.Products
                .Where(p=>p.Stock>0)
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
            var product = context.Products.Select(p => new ProductDto
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
            }).FirstOrDefault(s => s.Id==id);
            if (product is null)
                throw new Exception("El producto no existe.");
            return product;
        }

        public Product GetProductC(int id)
        {
            var product = context.Products.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                Price = p.Price,
                Sku = p.Sku,
                Description = p.Description,
                Brand = p.Brand
            }).FirstOrDefault(s => s.Id == id);
            if (product is null)
                throw new Exception("El producto no existe.");
            return product;
        }

        public void UpdateProduct(ProductDto product)
        {
            var products = context.Products.FirstOrDefault(p => p.Id == product.Id);
            try
            {
                products.Name = product.Name;
                products.Price = product.Price;
                products.Description = product.Description;
                products.Brand = product.Brand;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateStock(int cantidad,int id)
        {
            var products = context.Products.FirstOrDefault(p=>p.Id==id);
            try
            {
                products.Stock = products.Stock + cantidad;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStockPurchase(int id)
        {
            var products = context.Products.FirstOrDefault(p => p.Id == id);
            try
            {
                products.Stock = products.Stock - 1;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null)
                throw new Exception($"No existe ningun producto con el Id: {id}");

            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
