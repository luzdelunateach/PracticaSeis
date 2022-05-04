using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Subdepartment> Subdepartments { get; set; }
        public Department()
        {

        }

        public Department(string name, List<Subdepartment> subdepartments)
        {

            Name = name;
            Subdepartments = subdepartments;
        }
    }
}
