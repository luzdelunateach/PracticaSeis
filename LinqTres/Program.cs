using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTres
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            // C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
            
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

            var n = from x in arr1
                    group x by x into y
                    select y;

            var n1 = arr1
                .GroupBy(x => x)
                .Select(y => y);

            
                

            Console.WriteLine("The number and the Frequency are : \n");

            foreach (var arrNo in n)
            {
                Console.WriteLine("Number" + arrNo.Key + " appears " + arrNo.Count() + " times");
            }
            Console.WriteLine("\n");

            // C.2 Write a program in C# Sharp to display a list of unrepeated numbers.

            int[] arrN = arr1.Distinct().ToArray();

            for(int i=0;i<arrN.Length;i++)
            {
                Console.WriteLine("Unrepeated numbers: "+arrN[i]);
            }


            // C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
            var m = from x in arr1
                    group x by x into y
                    select y;
            Console.Write("Nmero" + "\t" + "Numero por frecuenta * frecuencia " + "\t" + "Frecuencia" + "\n");
          

            foreach (var arrEle in m)
            {
                Console.WriteLine(arrEle.Key + "\t" + arrEle.Sum() + "\t\t\t" + arrEle.Count());
            }
        }
    }
}
