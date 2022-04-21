using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePOO
{
    class DataBase
    {
        public static List<Activity> activityE = new List<Activity>()
        {
            new Activity("Realize la revision de las actividades de los trabajadores 1",new DateTime(2021,2,2),3,false,1,1),
            new Activity("Realize la revision de las actividades de los trabajadores 2",new DateTime(2021,2,10),5,false,2,2),
            new Activity("Realize la revision de las actividades de los trabajadores 3",new DateTime(2021,2,11),8,false,1,3),
            new Activity("Realize la revision de las actividades de los trabajadores 4",new DateTime(2021,2,2),5,false,1,4),
            new Activity("Realize la revision de las actividades de los trabajadores 5",new DateTime(2021,2,21),8,false,3,1),
            new Activity("Realize la revision de las actividades de los trabajadores 6",new DateTime(2021,2,23),9,false,3,2),
            new Activity("Realize la revision de las actividades de los trabajadores 7",new DateTime(2021,2,23),9,false,3,3)
        };

        public static  List<User> user = new List<User>() {
                new Employee(1,"pablo1","pablo22",new DateTime(1995,3,25),"worker", activityE),
                new Manager(2,"juan1","juan3",new DateTime(1995,3,25),"supervisor",activityE),
                new Employee(3,"luna1","luna22",new DateTime(1995,3,25),"worker", activityE)
        };

        public static List<Project> projectSeed = new List<Project>()
        {
            new Project(1,"Projecto1",new DateTime(2021,1,12),"El primer proyecto"),
            new Project(2,"Projecto2",new DateTime(2021,2,13),"El segundo proyecto"),
            new Project(3,"Projecto3",new DateTime(2021,3,14),"El tercero proyecto"),
            new Project(4,"Projecto4",new DateTime(2021,4,15),"El cuarto proyecto")
        };
    }


}
