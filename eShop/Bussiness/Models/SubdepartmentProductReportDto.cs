using System;
using System.Collections.Generic;

namespace Bussiness.Models
{
    public class SubdepartmentProductReportDto
    {
        public string Subdepartment { get; set; }
        public List<ProductReportDto> Productos { get; set; }
    }
}
