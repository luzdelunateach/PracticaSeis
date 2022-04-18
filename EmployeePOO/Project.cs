using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePOO
{
    class Project
    {
        public int IdProject { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public string Description { get; set; }
        private int _idSeed = 1;

        public Project(int? id, string name, DateTime? date, string description)
        {
            if(name == null)
                throw new ArgumentNullException("El nombre del proyecto no puede estar vacio.");
            if(description == null)
                throw new ArgumentNullException("La descripción del proyecto no puede estar vacia.");

            IdProject= _idSeed++;
            Name = name;
            Date = date ?? DateTime.Today;
        }
    }
}
