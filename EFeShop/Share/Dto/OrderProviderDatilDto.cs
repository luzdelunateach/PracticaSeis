using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class OrderProviderDatilDto
    {
        public int ProductId { get; set; }

        public OrderProviderDatilDto()
        {

        }
        public OrderProviderDatilDto(int productoId)
        {
            ProductId = productoId;
        }
    }
}
