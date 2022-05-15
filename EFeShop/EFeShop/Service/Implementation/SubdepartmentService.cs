using EFeShop.Service.Abstraction;
using Model;
using Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Implementation
{
    public class SubdepartmentService:ISubdepartmentService
    {
        private readonly AppDbContext context = new AppDbContext();

        public List<SubdeparmentDto> GetAll()
        {
            var subdepartment = context.Subdepartments.Select(s => new SubdeparmentDto
            {
                Id = s.Id,
                Name = s.Name,
                DepartmentName = s.Department.Name
            }).ToList();

            if (!subdepartment.Any())
                throw new Exception("No hay subdepartamentos.");

            return subdepartment;
        }
        
    }
}
