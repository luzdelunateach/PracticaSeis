using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Entities
{
    public class Department
    {
        public string Name { get; private set; }
        public List<Subdepartment> Subdeparments { get; private set; }

        public Department(string name, List<Subdepartment> subdepartments)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede ser vacio");

            if (subdepartments == null || !subdepartments.Any())
                throw new InvalidOperationException("El departamento necesita subdepartamentos");

            Name = name;
            Subdeparments = subdepartments;
        }
    }
}
