using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeePOO
{
    class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateIni { get; set; }
        public string? Role { get; set; }
        public List<Activity> ListActivities { get; set; } = new List<Activity>();

        public int  _idSeed = 4;

        static int _userSesionSeed = 0;
        static Manager managerMethods = new Manager();
        static Employee employeeMethods = new Employee();

        public User()
        {

        }

        public User(int Id, string UserName, string Password, DateTime DateIni, string Role, List<Activity> ListActivities)
        {
            if(UserName == null)
                throw new ArgumentNullException("El usuario no puede estar vacio.");
            if(Password == null)
                throw new ArgumentNullException("El password no puede estar vacio.");

            this.Id = Id;
            this.UserName = UserName;
            this.Password = Password;
            this.DateIni = DateTime.Today;
            this.Role = Role;
            this.ListActivities = ListActivities;
        }

        public void Login()
        {
            var u = ReadUser();
            var p = ReadPassword();

            var e = FindUser(u,p);
            if (e != null)
            {
                Console.WriteLine($"Welcome user:{e.UserName}");
                //do{
                   if (e.Role.Equals("supervisor")) {
                            DateTime today = DateTime.Today;
                            if (e.DateIni == today) 
                            {
                                Console.WriteLine("Congratulations on your anniversary");
                            }
                            Console.WriteLine($"WELCOME: {e.UserName}");
                            _userSesionSeed = e.Id;
                            managerMethods.MenuManager();
                    }
                    else {
                            DateTime today = DateTime.Today;
                            if (e.DateIni == today) 
                            {
                                Console.WriteLine("Congratulations on your anniversary");
                            }
                            Console.WriteLine($"WELCOME: {e.UserName}");
                            _userSesionSeed = e.Id;
                            employeeMethods.MenuWorker();
                    }
                //}while (_userSesionSeed != 0);
            }
        }

        public int IdUserInSesion()
        {
            return _userSesionSeed;
        }

        public User FindUser(string user, string password)
        {
            var e = DataBase.user.FirstOrDefault(x => x.UserName == user && x.Password == password);
            return e;
        }

        public string ReadUser()
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

        public string ReadPassword()
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
    }
}
