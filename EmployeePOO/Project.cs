using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EmployeePOO
{
    class Project
    {
        public int IdProject { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public string Description { get; set; }
        public int TotalHours { get; set; }

        static User userMethod = new User();
        public Project()
        {

        }
        public Project(int id, string name, DateTime? date, string description)
        {
            if (name == null)
                throw new ArgumentNullException("El nombre del proyecto no puede estar vacio.");
            if (description == null)
                throw new ArgumentNullException("La descripción del proyecto no puede estar vacia.");

            IdProject = id;
            Name = name;
            Date = date ?? DateTime.Today;
            TotalHours = 0;
        }
        public void MenuProjects()
        {
            int _userSesionSeed = userMethod.IdUserInSesion();
            do
            {

                Console.WriteLine("Projects\n");
                Console.WriteLine("Main\n1.Add Project\n2.Consult Projects\n3.Edit Project\n4.Delete Project\n5.Exit");

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
                            AddProject();
                            break;
                        case 2:
                            ConsultProject();
                            break;
                        case 3:
                            EditProject();
                            break;
                        case 4:
                            DeleteProject();
                            break;
                        case 5:
                        default:
                            break;
                    }
                }
            } while (_userSesionSeed != 0);
        }

        public static void AddProject()
        {
            var idU = DataBase.projectSeed.Last().IdProject + 1;
            Console.WriteLine($"Project Id: {idU}");

            Console.WriteLine("Add name project: ");
            var u = Console.ReadLine();
            if (String.IsNullOrEmpty(u))
            {
                Console.WriteLine("Please insert a valid User");
            }
            else
            {
                Console.WriteLine($"Date: {DateTime.Today}");
                Console.WriteLine("Description: ");
                var r = Console.ReadLine();
                if (String.IsNullOrEmpty(r))
                {
                    Console.WriteLine("Please insert a valid role");
                }
                else
                {
                    Console.WriteLine("Total Horas: 0");
                    Project NewProject = new Project(idU, u, DateTime.Today, r);
                    DataBase.projectSeed.Add(NewProject);
                }
            }
            Console.WriteLine("Congrats, you added a new project");
        }

        public void ConsultProject()
        {
            var lista = DataBase.projectSeed;
            foreach (var e in lista)
            {
                Console.WriteLine($"Id: {e.IdProject}\tNombre: {e.Name}\tFecha Creacion: {e.Date}\tDescripcion: {e.Description}\tTotal Horas: {e.TotalHours} \n");
            }
        }

        public static void EditProject()
        {
            Console.WriteLine("Project to Edit: (ID) ");
            var id = Console.ReadLine();
            if (!Int32.TryParse(id, out int idAux))
            {
                Console.WriteLine("Please insert a valid id");
            }
            else
            {
                var pro = DataBase.projectSeed.FirstOrDefault(x => x.IdProject == idAux);
                if (pro != null)
                {
                    Console.WriteLine("Change the name of the project: ");
                    var name = Console.ReadLine();
                    pro.Name = name;
                    Console.WriteLine("Change the description: ");
                    var desc = Console.ReadLine();
                    pro.Description = desc;
                }
            }
            
        }
        public static void DeleteProject()
        {
            Console.WriteLine("Project to Delete: (ID) ");
            var id = Console.ReadLine();
            if (!Int32.TryParse(id, out int idAux)) { 
                Console.WriteLine("Please insert a valid id");
            }else{
                var pro=DataBase.projectSeed.FirstOrDefault(x => x.IdProject == idAux);
                if (pro != null)
                {
                    DataBase.projectSeed.Remove(pro);
                }
            }
        }
    }
}
