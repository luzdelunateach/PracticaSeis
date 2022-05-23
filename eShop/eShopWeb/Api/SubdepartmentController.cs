using Bussiness.Models;
using Bussiness.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopWeb.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubdepartmentController : ControllerBase
    {
        private readonly ISubdepartmentService _subdepartmentService;

        public SubdepartmentController(ISubdepartmentService subdepartmentService)
        {
            _subdepartmentService = subdepartmentService;
        }

        [HttpGet]
        public async Task<List<SubdeparmentDto>> Get()
        {
            return await _subdepartmentService.GetAllAsync();
        }
    }
}
