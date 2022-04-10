using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePOO
{
    class DataBase
    {
        public static List<Employee> employees = new List<Employee>() {

                new Employee(){ Id = 1, User = "pablo1", Password="pablo22", DateIni = new DateTime(1995,3,25), Role = "supervisor",
                    ListActivities = {
                        new Activity(){Description = "Realize la revision de las actividades de los trabajadores", Date = new DateTime(2021,2,2), Hours = 8},
                        new Activity(){Description = "Realize la revision de las actividades de los trabajadores", Date = new DateTime(2022,4,7), Hours = 8}
                    }
                },

                new Employee(){ Id = 2, User = "juan1", Password="juan3", DateIni = new DateTime(1995,3,25), Role = "worker",
                    ListActivities = {
                        new Activity(){Description = "Realizar las tareas de testing", Date = new DateTime(1995,3,25), Hours = 8},
                        new Activity(){Description = "Realizar las tareas del spring", Date = new DateTime(2022,4,7), Hours = 8}
                    }
                }
         };
    }
}
