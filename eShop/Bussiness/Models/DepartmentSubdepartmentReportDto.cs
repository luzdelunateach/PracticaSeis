using System;
using System.Collections.Generic;

namespace Bussiness.Models
{
    public class DepartmentSubdepartmentReportDto
    {
        public string Department { get; set; }
        public List<SubdepartmentReportDto> Subdepartaments { get; set; }
    }
}
