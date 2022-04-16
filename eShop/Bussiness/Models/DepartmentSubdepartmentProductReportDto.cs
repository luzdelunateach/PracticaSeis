using System;
using System.Collections.Generic;

namespace Bussiness.Models
{
    public class DepartmentSubdepartmentProductReportDto
    {
        public string Department { get; set; }
        public List<SubdepartmentProductReportDto> Subdepartaments { get; set; }
    }
}
