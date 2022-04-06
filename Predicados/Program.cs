using System;
using System.Collections.Generic;

namespace PracticaSeis
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Predicate<int> predicate = new Predicate<int>(GetPairs);
            Predicate<int> predicateTwo = new Predicate<int>(GetPrimeNumbers);

            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            List<int> result = list.FindAll(predicate);
            List<int> primos = list.FindAll(predicateTwo);
            Console.WriteLine("Example Pairs");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Example Prime Numbers");
            foreach (var item in primos)
            {
                Console.WriteLine(item);
            }
            static bool GetPairs(int num)
            {
                if (num % 2 == 0) return true;
                else return false;
            }
            static bool GetPrimeNumbers(int num)
            {
                if(num % 2 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

    }
    
}