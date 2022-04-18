using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeePOO
{
    class Manager:User
    {
      
        public Manager(){
        }
        public Manager(int Id, string UserName, string Password, DateTime DateIni, string Role) : base(Id, UserName, Password, DateIni, Role)
        {
            
        }
        static User userMethod = new User();
        public void MenuManager()
        {
            Console.Clear();
            Console.WriteLine("Manager\n");
            Console.WriteLine("Main\n1.Add Worker\n2.Edit Worker\n3.Delete Worker\n4.Check Activitys\n5.Exit ");

            var res = Console.ReadLine();

            if(!Int32.TryParse(res, out int resp))
            {
                Console.WriteLine("Please insert an integer");
                return;
            }
            else
            {
                switch (resp)
                {
                    case 1:
                        AddWorker();
                        break;
                    case 2:
                        EditWorker();
                        break;
                    case 3:
                        DeleteWorker();
                        break;
                    case 4:
                        ValidateTask();
                        break;
                }
            }
        }

        public static void AddWorker()
        {
            Console.WriteLine("User Id:");
            var idU = Console.ReadLine();
            if (!Int32.TryParse(idU, out int idUser))
            {
                Console.WriteLine("Please insert an integer");
            }
            else
            {
                Console.WriteLine("User: ");
                var u = Console.ReadLine();
                if (String.IsNullOrEmpty(u))
                {
                    Console.WriteLine("Please insert a valid User");
                }
                else
                {
                    Console.WriteLine("Password:");
                    var p = Console.ReadLine();
                    if (String.IsNullOrEmpty(p))
                    {
                        Console.WriteLine("Please insert a valid password");
                    }
                    else
                    {
                        Console.WriteLine("Date: ");
                        var d = Console.ReadLine();
                        Console.WriteLine("Role: ");
                        var r = Console.ReadLine();
                        if (String.IsNullOrEmpty(r))
                        {
                            Console.WriteLine("Please insert a valid role");
                        }
                        else
                        {
                            Employee NewEmployee = new Employee(0,u,p,DateTime.Today,"worker",null);
                            DataBase.user.Add(NewEmployee);
                        }

                    }
                }
            }
            Console.WriteLine("Congrats, you added a new user");
        }

        public static void EditWorker()
        {
            Console.WriteLine("Username to Edit: ");
            var userE = Console.ReadLine();
            var e = DataBase.user.FirstOrDefault(x => x.UserName == userE);
            if (e != null)
            {
                Console.WriteLine("Change the name of the user: ");
                var user = Console.ReadLine();
                e.UserName = user;
                Console.WriteLine("Change the password: ");
                var password = Console.ReadLine();
                e.Password = password;
            }
        }

        public static void DeleteWorker()
        {
            Console.WriteLine("Username to Delete: ");
            var userE = Console.ReadLine();
            var worker = DataBase.user.FirstOrDefault(x => x.UserName == userE);
            if (worker != null)
            {
                DataBase.user.Remove(worker);
            }

        }

        public static void ValidateTask()
        {
            Console.WriteLine("Metodo en proceso");
            /*Console.WriteLine("User to validate Task: ");
            var w = Console.ReadLine();
            var emp = DataBase.user.FirstOrDefault(x => x.UserName == w);
            if (emp != null)
            {
                foreach (Activity x in emp)
                {
                    Console.WriteLine($"User\tDescription\tDate\tHours\n{emp.User}\t{x.Description}\t{x.Date}\t{x.Hours}");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }
                Console.WriteLine("Do you want to validate? (y/n)");
                var resp = Console.ReadLine();
                if (resp.Equals("y"))
                {
                    emp.ListActivities.RemoveAll(act => emp.User == w);
                    Console.WriteLine("OK!");
                }
            }
            else
            {
                Console.WriteLine("Worker doesn't have any activity yet");
            }*/

        }
    }
}
