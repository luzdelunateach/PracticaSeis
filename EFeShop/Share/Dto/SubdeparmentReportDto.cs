using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class SubdeparmentReportDto
    {
        public string Subdepartment { get; set; }
        public List<ProductDto> Productos { get; set; }
    }
}
