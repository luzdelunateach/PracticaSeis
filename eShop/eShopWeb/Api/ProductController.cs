using Bussiness.Models;
using Bussiness.Services.Abstractions;
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
        public ProductController (IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<ProductDto>> Get()
        {
            return await _productService.GetAll();
        }
    }
}
