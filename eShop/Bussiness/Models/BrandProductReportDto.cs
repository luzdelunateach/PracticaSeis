using System;
using System.Collections.Generic;

namespace Bussiness.Models
{
    public class BrandProductReportDto
    {
        public string Brand { get; set; }
        public List<ProductReportDto> Productos { get; set; }
    }
}
