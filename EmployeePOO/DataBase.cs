using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePOO
{
    class DataBase
    {
        public static List<Employee> employees = new List<Employee>() {

                new Employee(1,"pablo1","pablo22",new DateTime(1995,3,25),"supervisor"){
                    ListActivities = {
                        new Activity(){Description = "Realize la revision de las actividades de los trabajadores", Date = new DateTime(2021,2,2), Hours = 8,
                        Valid = false},
                        new Activity(){Description = "Realize la revision de las actividades de los trabajadores", Date = new DateTime(2022,4,7), Hours = 8,
                        Valid = false}
                    }
                },

                new Employee(2,"juan1","juan3"){ DateIni = new DateTime(1995,3,25), Role = "worker",
                    ListActivities = {
                        new Activity(){Description = "Realizar las tareas de testing", Date = new DateTime(1995,3,25), Hours = 8, Valid = false},
                        new Activity(){Description = "Realizar las tareas del spring", Date = new DateTime(2022,4,7), Hours = 8, Valid = false}
                    }
                }
         };
    }
}
