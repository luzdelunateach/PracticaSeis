using Bussiness.Models;
using Bussiness.Services.Abstractions;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopWeb.Api
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ISubdepartmentService _subdepartmentService;

        public ProductController (IProductService productService, ISubdepartmentService subdepartmentService)
        {
            _productService = productService;
            _subdepartmentService = subdepartmentService;
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<Product> Create(ProductRegistryDto product)
        {

            var sub = await _subdepartmentService.GetAsync(product.SubdepartmentId);
            var p = new Product(product.Name, product.Stock, product.Price, product.Sku, product.Description, product.Brand, sub);
            return await _productService.AddAsync(p);
        }

        [HttpGet]
        public async Task<List<ProductDto>> Get()
        {
            return await _productService.GetAll();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            /*if (!ModelState.IsValid)
                return null;*/
            var article = await _productService.GetAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return await _productService.DeleteAsync(id);

        }

        [HttpPut]
        public async Task<Product> Edit(ProductDto product)
        {
            /*if (!ModelState.IsValid)
                return null;*/
            return await _productService.EditAsync(product);
        }
    }
}
