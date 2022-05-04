using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    class DepartmentReportDto
    {
        public string Department { get; set; }
        public List<SubdeparmentReportDto> Subdepartment { get; set; }
    }
}
