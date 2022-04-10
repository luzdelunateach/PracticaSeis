using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePOO
{
    class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; }
        
        public User(int Id, string UserName, string Password)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
