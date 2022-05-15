using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class BrandReportDto
    {
        public string Brand { get; set; }
        public List<ProductDto> Productos { get; set; }
    }
}
