using System;

namespace LeftRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] original = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Hello there, insert a number please.");
            int d;
            if(Int32.TryParse(Console.ReadLine(), out d))
            {
                Rotate(original, d);
            }
        }

        public static void Rotate(int[] array, int d)
        {
            int aux = 0;
            for(int j = 0; j < d; j++)
            {
                int k = 1;
                for (int i=0; i<array.Length; i++)
                {
                    if (i == 0)
                        aux = array[i];
                    if (k == array.Length)
                        array[i] = aux;
                    else
                    {
                        array[i] = array[k];
                        k++;
                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Value: { array[i]}");
            }
            
        }
    }
}
