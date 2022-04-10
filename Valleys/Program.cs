using System;

namespace Valleys
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateValleys() ;
        }

        public static void CalculateValleys()
        {
            string[] s = new string[]{ "U","D","D","U","D","U","U"};
            int level = 0;
            int valley = 0;
            for(int i=0; i<s.Length; i++)
            {
                if (s[i].Equals("U"))
                {
                    level++;
                    
                }
                else if (s[i].Equals("D"))
                {
                    level--;
                    if(level == 0)
                    {
                        valley++;
                    }
                }
                
            }
            Console.WriteLine($"Numero de villas es:{valley}");
        }
    }
}
