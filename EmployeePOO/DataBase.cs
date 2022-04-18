using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePOO
{
    class DataBase
    {
        public static List<Activity> activityE = new List<Activity>()
        {
            new Activity("Realize la revision de las actividades de los trabajadores",new DateTime(2021,2,2),8,false,1),
            new Activity("Realize la revision de las actividades de los trabajadores",new DateTime(2021,2,2),8,false,2)
        };
        public static  List<User> user = new List<User>() {
                new Employee(1,"pablo1","pablo22",new DateTime(1995,3,25),"worker", activityE),
                new Manager(2,"juan1","juan3",new DateTime(1995,3,25),"supervisor"),
                new Employee(3,"luna1","luna22",new DateTime(1995,3,25),"worker", activityE)
        };
    }


}
