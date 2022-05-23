using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Models;
using Bussiness.Services.Abstractions;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        /* public async Task<Product> RegisterProduct(ProductRegistryDto productRegistry)
         {
             var subdeparment = _context.Subdepartments.FirstOrDefault(s => s.Id == productRegistry.SubdepartmentId);
             var product = new Product(productRegistry.Name, productRegistry.Stock, productRegistry.Price, productRegistry.Sku, productRegistry.Description, productRegistry.Brand, subdeparment);

             try
             {
                 if (subdeparment is null)
                     throw new ArgumentNullException("El subdepartamento no existe.");



                 _context.Products.Add(product);
                 _context.SaveChanges();
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }*/

        public async Task<Product> AddAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<List<ProductDto>> GetAll()
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
            }).ToListAsync();

            return await products;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity == null)
                return false;

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> EditAsync(ProductDto product)
        {
            var entity = await _context.Products.FindAsync(product.Id);
            if (entity == null)
                return default;

            //entity.Edit(movie.Title, movie.Body);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.Include(a => a.Subdepartment).FirstOrDefaultAsync(a => a.Id == id);
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