using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePOO
{
    class Program
    {
        
        static User userMethods = new User();
        static void Main(string[] args)
        {
            
            Console.WriteLine("¡Good Morning!");
            userMethods.Login();
        }
    }
}
