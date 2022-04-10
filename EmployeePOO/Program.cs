using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePOO
{
    class Program
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

        static int userSesionSeed = 0;
        static void Main(string[] args)
        {
            Login();
        }

        //hacer un pull request

        public static void Login()
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
                            employees.Add(new Employee
                            {
                                Id = idUser,
                                User = u,
                                Password = p,
                                DateIni = DateTime.Today,
                                Role = "worker",
                                ListActivities = {
                                new Activity(){Description = "Darlo de alta", Date = DateTime.Today, Hours = 0}}
                                });
                            Console.WriteLine("Congrats, you added a new user");
                        }
                        
                    }
                }
            }
            
        }

        public static void EditWorker()
        {
            Console.WriteLine("User to Edit: ");
            var userE= Console.ReadLine();
            var e = employees.FirstOrDefault(x => x.User == userE);
            if (e!=null)
            {
                Console.WriteLine("Change the name of the user: ");
                var user = Console.ReadLine();
                e.User = user;
                Console.WriteLine("Change the password: ");
                var password = Console.ReadLine();
                e.Password = password;
                Console.WriteLine("Change the role: ");
                var role = Console.ReadLine();
                e.Role = role;
            }
        }

        public static void DeleteWorker()
        {
            Console.WriteLine("User to Delete: ");
            var userE = Console.ReadLine();
            var worker = employees.FirstOrDefault(x => x.User == userE);
            if (worker != null)
            {
                employees.Remove(worker);
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

        public static void AddActivity()
        {
            Console.WriteLine("User to add activity: ");
            var userE = Console.ReadLine();
            var worker = employees.FirstOrDefault(x => x.User == userE);
            if (worker != null)
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
        }
    }
}
