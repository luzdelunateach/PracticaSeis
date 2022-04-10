using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePOO
{
    class Employee : User
    {
       
        public DateTime DateIni { get; set; }
        public string? Role { get; set; }
        public List<Activity> ListActivities { get; set; } = new List<Activity>();
        
        public Employee()
        {

        }
    }
}
