
using Bussiness.Models;
using Bussiness.Services.Abstractions;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Implementations
{
    public class SubdepartmentService:ISubdepartmentService
    {
        private readonly AppDbContext _context;

        public SubdepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public List<SubdeparmentDto> GetAll()
        {
            var subdepartment = _context.Subdepartments.Select(s => new SubdeparmentDto
            {
                Id = s.Id,
                Name = s.Name,
                DepartmentName = s.Department.Name
            }).ToList();

            if (!subdepartment.Any())
                throw new Exception("No hay subdepartamentos.");

            return subdepartment;
        }

        public async Task<List<SubdeparmentDto>> GetAllAsync()
        {
            var subdepartment =  _context.Subdepartments.Select(s => new SubdeparmentDto
            {
                Id = s.Id,
                Name = s.Name,
                DepartmentName = s.Department.Name
            }).ToListAsync();

            return await subdepartment;
        }

        public async Task<Subdepartment> GetAsync(int id)
        {
            return await _context.Subdepartments.FirstOrDefaultAsync(s=>s.Id==id);
        }
    }
}
