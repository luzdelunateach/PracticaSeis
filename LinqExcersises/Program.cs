using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExcersises
{
    class Program
    {
        public static List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

        

        static void Main(string[] args)
        {

            string[] cities =
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };


            // B.1 Find the string which starts and ends with a specific character : AM
            var city = cities
                .Where(c=>c.StartsWith("AM")&&c.EndsWith("AM"));

            foreach (var x in city)
            {
                Console.WriteLine("City which starts and ends with AM is:"+x);
            }

            // B.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.

            var items = cities
                .OrderBy(c => c)
                .GroupBy(c => c.Length)
                .Select(c => c);

            foreach (var x in items)
            {
                Console.WriteLine("Length:" + x);
            }

            // B.3 Write a program in C# Sharp to split a collection of strings into 3 random groups
            //tarea



            // Find the words in the collection that start with the letter 'L'

          
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            var res1 = fruits
                .Where(fruit => fruit.StartsWith('L'))
                .Select(fruit => $"Fruits that start with the letter L {fruits}");

            Console.WriteLine(string.Join(" ",fruits));


            // Which of the following numbers are multiples of 4 or 6
            List<int> mixedNumbers = new List<int>() { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96 };

            var mix = mixedNumbers
                .Where(mixedNumber => (mixedNumber % 4 == 0 || mixedNumber % 6 == 0));


            foreach (var x in mix)
            {
                Console.WriteLine(x);
            }

            // Output how many numbers are in this list
            List<int> numbers = new List<int>() { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96 };
            var res3 = numbers.Count;
            Console.WriteLine(res3);



            //despliega cuantos millonarios hay por banco
            var millonaire = customers
                .GroupBy(c => c.Bank)
                .Select(bank => new { Bank = bank.Key, Millonarios = bank.Where(c => c.Balance > 100000) });

            var mil = customers
                .Where(b => b.Balance > 1000000)
                .GroupBy(b => b.Bank)
                .Select(b => new
                {
                    Bank = b.Key,
                    Millonarios = b.Count()
                });

            foreach (var c in mil)
            {
                Console.WriteLine("El mio sale asi:"+c.Bank+" "+c.Millonarios);
            }


            var mill = customers
                .Where(c => c.Balance > 1000000)
                .GroupBy(c => c.Bank)
                .Select(bank => new
                {
                    Bank = bank.Key,
                    Millonarios = bank.Count() 
                });
            Console.WriteLine(string.Join(",", mill.Select(c => $"Banco: {c.Bank},Millonarios: {c.Millonarios}")));
            // hay que mostrr a los clientes que su balance sea mayor a 100,00
            //hay que ordenar a los clientes por su balance
            //hacer una sumatoria por riquza por cada banco

            var result4 = customers.Where(c => c.Balance < 100000 && c.Bank.Length == 3)
                .Select(c => $"{c.Name}{c.Balance}{c.Bank}");

            foreach (var c in result4)
            {
                Console.WriteLine(c);
            }

            var result3 = customers
                .GroupBy(c => c.Bank)
                .Select(c => new
                {
                    Bank = c.Key,
                    Total = c.Sum(customers => customers.Balance)
                });
            //mantener el nombre de los clientes que su balance sea menor a 100,000 y su banco tenga solo 3 caracteres.
            var millonarios = customers
                .Where(costum => costum.Balance > 999999.00);

            foreach(var custom in millonarios)
            {
                Console.WriteLine($"Los millonarios son:{custom.Name}{custom.Bank}");
            }

            var clientes = customers
                .Where(costum => costum.Balance > 100000.00);

            foreach (var custom in clientes)
            {
                Console.WriteLine($"Los clientes son:{custom.Name}{custom.Balance}");
            }

            var clientes2 = customers
                .OrderBy(costum => costum.Balance);

            foreach (var custom in clientes2)
            {
                Console.WriteLine($"Los clientes son:{custom.Name}{custom.Balance}");
            }

            
        }

    }
    internal class Customer
    {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }

}

