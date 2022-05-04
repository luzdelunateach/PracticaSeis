using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeePOO
{
    class ProjectUser
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }

        public ProjectUser()
        {

        }
        public ProjectUser(int Id, int IdUser, int IdProject)
        {
            this.Id = Id;
            this.IdUser = IdUser;
            this.IdProject = IdProject;
        }

        public void ConsultProjectUser(int idUser)
        {
            var consult = DataBase.UserProjectSeed.FindAll(u => u.IdUser == idUser);
            foreach (var u in consult)
            {
                var name = DataBase.user.FirstOrDefault(n=>n.Id==u.Id);
                var project = DataBase.projectSeed.FirstOrDefault(p=>p.IdProject==u.IdProject);
                Console.WriteLine($"Id: {u.Id}\tUsername: {name.UserName}\t Project: {project.Name}\n");
            }
        }
    }
}
