using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePOO
{
    class Program
    {
        static int userSesionSeed = 0;
        static void Main(string[] args)
        {
            Login();
        }

        public static void Login()
        {
            Console.WriteLine("¡Good Morning!");
            var u = ReadUser();
            var p = ReadPassword();

            var e = FindUser(u,p);
            if (e != null)
            {
                Console.WriteLine($"Bienvenido usuario:{e.UserName}");
                userSesionSeed = e.Id;
            }
        }

        public static User FindUser(string user, string password)
        {
            var e = DataBase.employees.FirstOrDefault(x => x.UserName == user && x.Password == password);
            return e;
        }

        static string ReadUser()
        {
            bool valid = false;
            string user = "";
            do
            {
                Console.WriteLine("Please, Insert your User");
                user = Console.ReadLine();
                if (string.IsNullOrEmpty(user))
                {
                    Console.WriteLine("Please insert a correct user");
                }
                else
                {
                    valid = true;
                }
            } while (valid!=true);

            return user;
        }

        static string ReadPassword()
        {
            bool valid = false;
            string password = "";
            do
            {
                Console.WriteLine("Password: ");
                password = Console.ReadLine();
                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Please insert a correct password");
                }
                else
                {
                    valid = true;
                }
            } while (valid != true);

            return password;
        }

        //hacer un pull request

        /*public static void Login()
        {
            do {
                Console.WriteLine("¡Good Morning!");
                Console.WriteLine("Please, Insert your User");
                var user = Console.ReadLine();
                if (string.IsNullOrEmpty(user))
                {
                    Console.WriteLine("Please insert a correct user");
                }
                Console.WriteLine("Password: ");
                var password = Console.ReadLine();
                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Please insert a correct password");
                }
                var employee = employees.FirstOrDefault(x => x.User == user && x.Password == password);
                if (employee!=null)
                {
                    userSesionSeed = employee.Id; //cambiar a id
                    do
                    {
                        if (employee.Role.Equals("supervisor")) {
                            DateTime today = DateTime.Today;
                            if (employee.DateIni == today) // TODO - Restar un año a hoy
                            {
                                Console.WriteLine("Congratulations on your anniversary");
                            }
                            Console.WriteLine($"WELCOME: {user}");
                            MenuSupervisor();
                        }
                        else {
                            DateTime today = DateTime.Today;
                            if (employee.DateIni == today) // TODO - Restar un año a hoy
                            {
                                Console.WriteLine("Congratulations on your anniversary");
                            }
                            Console.WriteLine($"WELCOME: {user}");
                            MenuWorker();
                        }
                    } while (userSesionSeed != 0);
                }
                else
                {
                    Console.WriteLine("Please verify that your user and password is correct");
                }
            } while (userSesionSeed==0);
        }
        //una persona puede tener muchas horas registradas
        //muchas

        public static void MenuSupervisor()
        {
            Console.WriteLine($"Supervirsor");
            
            Console.WriteLine("Main \n 1.Add Worker\n2.Edit Worker\n3.Delete Worker\n4.Check Activitys\n5.Exit ");

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
                            
                        }
                        
                    }
                }
            }
            
        }

       

      

        public static void MenuWorker()
        {
            Console.WriteLine($"Worker");
            Console.WriteLine("Main \n 1.Add Activitys 2.Exit ");
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

        

        public static void ValidateTask()
        {
            Console.WriteLine("User to validate Task: ");
            var w=Console.ReadLine();
            var emp = employees.FirstOrDefault(x => x.User == w );
            if (emp != null)
            {
                foreach (Activity x in emp.ListActivities)
                {
                    Console.WriteLine($"User\tDescription\tDate\tHours\n{emp.User}\t{x.Description}\t{x.Date}\t{x.Hours}");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }
                Console.WriteLine("Do you want to validate? (y/n)");
                var resp=Console.ReadLine();
                if (resp.Equals("y")){
                    emp.ListActivities.RemoveAll(act => emp.User == w);
                    Console.WriteLine("OK!");
                }
            }
            else
            {
                Console.WriteLine("Worker doesn't have any activity yet");
            }
            
        }

        public static void ClosedSession()
        {
            userSesionSeed = 0;
            Environment.Exit(0);
        }*/
    }
}
