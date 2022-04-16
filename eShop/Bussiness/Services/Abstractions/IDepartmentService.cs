using System;
using System.Collections.Generic;
using Data.Entities;

namespace Bussiness.Services.Abstractions
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartments();
        public List<Subdepartment> GetSubdepartments(string department);
    }
}
