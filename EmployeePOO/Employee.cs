using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeePOO
{
    class Employee : User
    {
        static User userMethod = new User();

        public Employee()
        {

        }

        public Employee(int Id, string UserName, string Password, DateTime DateIni, string Role, List<Activity> ListActivities):base(Id,UserName,Password,DateIni,Role, ListActivities)
        {

        }
        public void MenuWorker()
         {
            //Console.Clear();
            int _userSesionSeed = userMethod.IdUserInSesion();
            do
            {
                Console.WriteLine("Worker\n");
                Console.WriteLine("Main \n1.Add Activitys\n2.Consult Activities\n3.Exit ");
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
                            ConsultActivities();
                            break;
                        case 3:
                            ClosedSession();
                            break;
                    }

                }
            } while (_userSesionSeed != 0);
        }

        public static void AddActivity()
        {
           
            var idAux = userMethod.IdUserInSesion();
            var worker = DataBase.activityE.FirstOrDefault(x => x.Id == idAux);
            Console.WriteLine("Add de description: ");
            var description = Console.ReadLine();
            Console.WriteLine("Total of working hours: ");
            var hour = Console.ReadLine();
            if (!Int32.TryParse(hour, out int h))
                    Console.WriteLine("Please insert an integer");
            else
            {
               DataBase.activityE.Add(
                   new Activity(description, DateTime.Today, h, false, idAux,1)
               );
                Console.Write("Congrats!");
            }
        }

        public static void ConsultActivities()
        {
            var idAux = userMethod.IdUserInSesion();
            var emp = DataBase.user.FirstOrDefault(x => x.Id == idAux);
            Console.WriteLine($"Id: {emp.Id}\tUsuario: {emp.UserName}\tRole: {emp.Role}\n");
            var act = DataBase.activityE.Where(a => a.Id == emp.Id && a.Valid == false);
            foreach (var i in act)
            {
                Console.WriteLine($"Descripcion: {i.Description}\tFecha: {i.Date}\tHoras: {i.Hours}\n");
            }
        }
        public void ClosedSession()
        {
            Environment.Exit(0);
        }
    }
}
