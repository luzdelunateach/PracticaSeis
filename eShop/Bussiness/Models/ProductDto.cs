﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string SudepartmentName { get; set; }
        public string DepartmentName { get; set; }
    }
}
