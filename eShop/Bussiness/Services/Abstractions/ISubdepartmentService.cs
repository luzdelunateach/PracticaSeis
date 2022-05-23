using Bussiness.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstractions
{
    public interface ISubdepartmentService
    {
        List<SubdeparmentDto> GetAll();
        Task<List<SubdeparmentDto>> GetAllAsync();
        Task<Subdepartment> GetAsync(int id);
    }
}
