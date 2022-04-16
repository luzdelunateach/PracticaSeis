using System;
using System.Collections.Generic;
using Bussiness.Services.Abstractions;
using Data.Entities;

namespace Bussiness.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> DepartmentList = TestData.DepartmentList;

        public List<Department> GetDepartments()
        {
            return DepartmentList;
        }

        public List<Subdepartment> GetSubdepartments(string department)
        {
            return DepartmentList.Find(d => d.Name.ToLower().Equals(department.ToLower())).Subdeparments;
        }
    }
}
