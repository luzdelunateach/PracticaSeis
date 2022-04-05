using System;
using System.Collections.Generic;

namespace PracticaSeis
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Predicate<int> predicate = new Predicate<int>(GetPairs);

            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            List<int> result = list.FindAll(predicate);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
             static bool GetPairs(int num)
            {
                if (num % 2 == 0) return true;
                else return false;
            }

        }

    }
    
}