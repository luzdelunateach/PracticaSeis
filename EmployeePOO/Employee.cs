using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePOO
{
    class Employee
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public string Password { get; set; }
        public DateTime DateIni { get; set; }
        public string? Role { get; set; }
        public List<Activity> ListActivities { get; set; } = new List<Activity>();

       
    }
}
