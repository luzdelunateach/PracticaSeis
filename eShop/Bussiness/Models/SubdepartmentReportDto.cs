using System;
using System.Collections.Generic;

namespace Bussiness.Models
{
    public class SubdepartmentReportDto
    {
        public string Subdepartment { get; set; }
        public List<ProductReportDto> Productos { get; set; }
    }
}
