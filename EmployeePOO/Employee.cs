using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeePOO
{
    class Employee : User
    {
        public DateTime DateIni { get; set; }
        public string? Role { get; set; }
        public List<Activity> ListActivities { get; set; } = new List<Activity>();

        public Employee(int Id, string UserName, string Password, DateTime dateIni, string role, List<Activity> ListActivities):base(Id,UserName,Password)
        {
            this.DateIni = dateIni;
            this.Role = role;
            this.ListActivities = ListActivities;
        }

        static Employee()
        {

        }

        public static void AddActivity(string description, int hour, int id)
        {
            //Console.WriteLine("User to add activity: ");
            //var userE = Console.ReadLine();
            //var worker = DataBase.activityE.FirstOrDefault(x => x.Id == id);
            /*if (worker != null)
            {
                Console.WriteLine("Add de description: ");
                var description = Console.ReadLine();
                Console.WriteLine("Total of working hours: ");
                var hour = Console.ReadLine();
                if (!Int32.TryParse(hour, out int h))
                {
                    Console.WriteLine("Please insert an integer");

                }
                else
                {
                    worker.ListActivities.Add(
                        new Activity() { Description = description, Date = DateTime.Today, Hours = h }
                    );
                }

            }*/
            Activity a = new Activity(description, DateTime.Today, hour, false, id);
            DataBase.activityE.Add(a);

        }
    }
}
