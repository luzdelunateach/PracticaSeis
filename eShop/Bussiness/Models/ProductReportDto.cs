using Data.Entities;
using System;
using System.Collections.Generic;

namespace Bussiness.Models
{
    public class ProductReportDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
    }
}
