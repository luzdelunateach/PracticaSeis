using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class ProductRegistryDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int SubdepartmentId { get; set; }

        public void Validation()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentException("El nombre no debe estar vacio.");
            if (Stock <= 0)
                throw new ArgumentException("Stock no debe ser 0");
            if (Price <= 0)
                throw new ArgumentException("El precio no debe ser 0");
            if (string.IsNullOrEmpty(Sku))
                throw new ArgumentException("El SKU no debe estar vacio.");
            if (string.IsNullOrEmpty(Description))
                throw new ArgumentException("La descripción no debe estar vacia.");
            if (string.IsNullOrEmpty(Brand))
                throw new ArgumentException("La marca no debe estar vacia.");
            if (SubdepartmentId<=0)
                throw new ArgumentException("El id del Subdepartamento no puede ser menor o ser 0");
        }

    }
}
