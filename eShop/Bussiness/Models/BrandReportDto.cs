using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class BrandReportDto
    {
        public string Brand { get; set; }
        public List<ProductDto> Productos { get; set; }
    }
}
