using System;
using System.Collections.Generic;
using System.Linq;

namespace PeredicatesWithClases
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("Search: ");
            var input = Console.ReadLine();
            Searcher(input);
            //if (result)
            //    Console.WriteLine("Search");
            //else
                //Console.WriteLine("Usuario no existe");

            static void Searcher(string input)
            {
                User.Input = input;
                Predicate<Person> predicateByName = new Predicate<Person>(Person.Exists);
                Predicate<Person> predicateByAge = new Predicate<Person>(Person.GetByAge);
                Predicate<Person> predicateByBirth = new Predicate<Person>(Person.GetByBirth);
                List<Person> people = new List<Person>()//Filtrar por fecha de nacimiento con el dia exacto, Mes y Año rango
                {
                new Person() {Name = "Gildardo", Age = 27, Birthday = new DateTime(1995,3,25)},
                new Person() {Name = "Rene", Age = 31, Birthday = new DateTime(1991,1,25)},
                new Person() {Name = "Alejandra", Age = 27, Birthday = new DateTime(1995,2,25)}
                };
                if (people.Exists(predicateByName)) //no es el mismo de la clase persona -listas definidas por microsoft
                    Console.WriteLine("The user exists.");
                
                else{
                    //var result = people.FindAll(predicateByAge); //me trae todas las concidencias
                    var result = people.FindAll(predicateByBirth);
                    if (result.Any()) //determina una lista si tiene elementos - si tiene o no, pero puedo filtrar 
                    {
                        Console.WriteLine("We found these names");
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Name);
                        }
                    }
                    else
                        Console.WriteLine("We didn't not find any names");
                }
               // return people.Exists(predicateByName);
            }

        }

        
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }

        public static bool Exists(Person person)
        {
            return person.Name.Equals(User.Input);
            
        }
        public static bool GetByAge(Person person)
        {
            var isNumber = Int32.TryParse(User.Input, out int age); //validar que no haya entrado una palabra
            if (isNumber)
                return person.Age.Equals(age);
            else
                return false;
        }
        public static bool GetByBirth(Person person)
        {
            var birthday = Int32.TryParse(User.Input, out int Birthday);//Entero
            if (birthday)
                return person.Birthday.Equals(Birthday);
            else
                return false;
        }
    }
    class User
    {
        public static string Input { get; set; }
    }
}
