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

        public Manager(int Id, string UserName, string Password, DateTime DateIni, string Role, List<Activity> ListActivities) : base(Id, UserName, Password, DateIni, Role, ListActivities)
        {

            
        }

        static User userMethod = new User();
        static Project projectMethod = new Project();
        public void MenuManager()
        {
            int _userSesionSeed = userMethod.IdUserInSesion();
            do
            {
                //Console.Clear();
                Console.WriteLine("Manager\n");
                Console.WriteLine("Main\n1.Add Worker\n2.Consultar Worker\n3.Edit Worker\n4.Delete Worker\n5.Add project to user\n6.Check Activitys\n7.Menu Projects\n8.Exit");

                var res = Console.ReadLine();

                if (!Int32.TryParse(res, out int resp))
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
                            ConsultarWorker();
                            break;
                        case 3:
                            EditWorker();
                            break;
                        case 4:
                            DeleteWorker();
                            break;
                        case 5:
                            AddProjectToUser();
                            break;
                        case 6:
                            ValidateTask();
                            break;
                        case 7:
                            projectMethod.MenuProjects();
                            break;
                        case 8:

                        default:
                            break;
                    }
                }
            } while (_userSesionSeed != 0);
        }

        public static void AddWorker()
        {
            var idU = DataBase.user.Last().Id + 1;
            Console.WriteLine($"User Id: {idU}");
            
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
                   Console.WriteLine($"Date: {DateTime.Today}");  
                   Console.WriteLine("Role: ");
                   var r = Console.ReadLine();
                    if (String.IsNullOrEmpty(r))
                    {
                      Console.WriteLine("Please insert a valid role");
                    }
                    else
                    {
                            Employee NewEmployee = new Employee(idU,u,p,DateTime.Today,"worker",null);
                            DataBase.user.Add(NewEmployee);
                    }

                   }
            }
            Console.WriteLine("Congrats, you added a new user");
        }

        public static void ConsultarWorker()
        {
            var lista = DataBase.user;
            foreach (var e in lista)
            {
                Console.WriteLine($"Id: {e.Id}\tUsuario: {e.UserName}\tPassword: {e.Password}\tRole: {e.Role}\tFecha de Ingreso: {e.DateIni} \n");
            }
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
        public void AddProjectToUser()
        {
            Console.WriteLine("***Add project to user***");
            Console.WriteLine("***Users***");
            ConsultarWorker();
            Console.WriteLine("***Projects***");
            projectMethod.ConsultProject();
            Console.WriteLine("Write id of the project");
            Console.Write("Id Project: ");
            var idP = Console.ReadLine();
            if (!Int32.TryParse(idP, out int idPAux))
            {
                Console.WriteLine("Please insert an integer");
                return;
            }
            else
            {
                Console.WriteLine("Write id of the user");
                Console.Write("Id Project: ");
                var idU = Console.ReadLine();
                if (!Int32.TryParse(idU, out int idUAux))
                {
                    Console.WriteLine("Please insert an integer");
                    return;
                }
                else
                {
                    var id = DataBase.UserProjectSeed.Last().Id + 1;
                    ProjectUser ProjectUser = new ProjectUser(id, idUAux, idPAux);
                    DataBase.UserProjectSeed.Add(ProjectUser);
                    Console.WriteLine("¡You added a new project to a worker!");
                }
            }
            
        }
        public static void ValidateTask()
        {
            Console.WriteLine("User to validate Task: ");
            var w = Console.ReadLine();
            var emp = DataBase.user.FirstOrDefault(x => x.UserName == w);
            Console.WriteLine($"Id: {emp.Id}\tUsuario: {emp.UserName}\tRole: {emp.Role}\n");
            var act = DataBase.activityE.Where(a => a.Id == emp.Id && a.Valid == false);
            foreach (var i in act)
            {
                Console.WriteLine($"Descripcion: {i.Description}\tFecha: {i.Date}\tHoras: {i.Hours}\n");
            }
            Console.WriteLine("Do you want to validate ? (y / n)");
            var resp = Console.ReadLine();
            if (resp.Equals("y"))
            {
                var val = DataBase.activityE.Where(a => a.Id == emp.Id);
                foreach (var i in val)
                {
                    i.Valid = true;
                }
                Console.WriteLine("OK!");
            }
            else
            {
                DataBase.activityE.RemoveAll(a => a.Id == emp.Id);
                Console.WriteLine("OK! Deleted");
            }
        }
    }
}
