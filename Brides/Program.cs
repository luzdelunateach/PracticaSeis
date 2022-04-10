using System;

namespace Brides
{
    class Program
    {
        static void Main(string[] args)
        {
            Brides();
        }
        
        public static void Brides()
        {
            int[] row = new int[]{4,1,2,3,5};
            int brides = 0;
            int r = 0;
            for (int i=0;i<row.Length;i++)
            {
                r = row[i] - (i + 1);
                if (r > 2)
                {
                    Console.WriteLine("Too Chaotic xD");
                    break;
                }
                else if(r > 0 && r < 2)
                {
                    brides++;
                }
            }
            Console.WriteLine($"Brides: {brides}");

        }
    }
}
