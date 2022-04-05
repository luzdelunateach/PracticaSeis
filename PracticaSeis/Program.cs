using System;
using System.Collections.Generic;

namespace PracticaSeis
{
    class Program
    {
        delegate void Del();
        delegate void Del2(string message);

        static void Main(string[] args)
        {
            MainMethod();
            //list
            static void MainMethod()
            {
                Delegate del = new Del(Message.Show);
                //del();
                Del2 del2 = new Del2(Message2.Show);
                del2("Goodbye world");
            }
        }

        
    }
    class Message
    {
        public static void Show()
        {
            Console.WriteLine("Hello World");

        }
    }
    class Message2
    {
        public static void Show(string message)
        {
            Console.WriteLine(message);
        }
    }
    class LambdaExpression
    {
        private static List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static List<int> getPairs()
        {
            return list.FindAll(x => x % 2 == 0);
        }
    }
}
