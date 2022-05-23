using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class ProductRegistryDto
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
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
            
        }

     

    }
}
