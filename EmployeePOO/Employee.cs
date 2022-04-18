using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeePOO
{
    class Employee : User
    {
        static User userMethods = new User();
        public List<Activity> ListActivities { get; set; } = new List<Activity>();

        public Employee()
        {

        }

        public Employee(int Id, string UserName, string Password, DateTime DateIni, string Role, List<Activity> ListActivities):base(Id,UserName,Password,DateIni,Role)
        {
           
            this.ListActivities = ListActivities;
        }
        public void MenuWorker()
         {
            Console.Clear();
            Console.WriteLine("Worker\n");
            Console.WriteLine("Main \n1.Add Activitys\n2.Exit ");
            var op = Console.ReadLine();
            if (!Int32.TryParse(op, out int opcion))
            {
                Console.WriteLine("Please insert an integer");
            }
            else
            {
                switch (opcion)
                {
                    case 1:
                        AddActivity();
                        break;
                    case 2:
                        ClosedSession();
                        break;
                }
                
            }
        }

        public static void AddActivity()
        {
            Console.WriteLine("User to add activity: ");
            var userE = Console.ReadLine();
            var idAux = userMethods.IdUserInSesion();
            var worker = DataBase.activityE.FirstOrDefault(x => x.Id == idAux);
            if (worker != null)
            {
                Console.WriteLine("Add de description: ");
                var description = Console.ReadLine();
                Console.WriteLine("Total of working hours: ");
                var hour = Console.ReadLine();
                if (!Int32.TryParse(hour, out int h))
                    Console.WriteLine("Please insert an integer");
                else
                {
                    DataBase.activityE.Add(
                        new Activity(description, DateTime.Today, h, false, idAux)
                    ); 
                }

            }
        }

        public void ClosedSession()
        {
            Environment.Exit(0);
        }
    }
}
