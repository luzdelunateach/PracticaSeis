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
        
        public Employee(int Id, string UserName, string Password, DateTime dateIni, string role):base(Id,UserName,Password)
        {
            this.DateIni = dateIni;
            this.Role = role;
        }
    }
}
