using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeePOO
{
    class Manager:User
    {
        public DateTime DateIni { get; set; }
        public string? Role { get; set; }
        public Manager(int Id, string UserName, string Password, DateTime dateIni, string role) : base(Id, UserName, Password)
        {
            this.DateIni = dateIni;
            this.Role = role;
        }

        public void AddWorker(int id, string user, string password, List<Activity> ListActivity)
        {
            Employee e = new Employee(id, user, password, DateTime.Today, "worker", ListActivity);
            DataBase.employees.Add(e);
            //Console.WriteLine("Congrats, you added a new user");
        }

        public static void EditWorker(string user)
        {
            //Console.WriteLine("User to Edit: ");
            //var userE = Console.ReadLine();
            
            var e = DataBase.employees.FirstOrDefault(x => x.UserName == user);
            if (e != null)
            {
                Console.WriteLine("Change the name of the user: ");
                var u = Console.ReadLine();
                e.UserName = user;
                Console.WriteLine("Change the password: ");
                var password = Console.ReadLine();
                e.Password = password;
            }
        }

        public static void DeleteWorker(string user)
        {
            Console.WriteLine("User to Delete: ");
            var userE = Console.ReadLine();
            var worker = DataBase.employees.FirstOrDefault(x => x.UserName == user);
            if (worker != null)
            {
                DataBase.employees.Remove(worker);
            }

        }
    }
}
