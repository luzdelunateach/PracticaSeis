using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class OrderProviderRegestryDto
    {
        public decimal Total { get; set; }
        public DateTime PurchaseDate { get; set; }
        public PurchaseOrderStatus? Status { get; set; }
        public int ProviderId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public void Validation()
        {
            if (Total <= 0)
                throw new ArgumentException("El total no debe ser 0");
            if (ProviderId <= 0)
                throw new ArgumentException("El id del Proveedor no puede ser menor o ser 0");
            if (ProductoId <= 0)
                throw new ArgumentException("El id del Producto no puede ser menor o ser 0");
        }
    }
    
}
