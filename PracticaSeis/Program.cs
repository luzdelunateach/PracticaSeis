using System;

namespace PracticaSeis
{
    class Program
    {
        delegate void Del();
        delegate void Del2(string message);

        static void Main(string[] args)
        {
            MainMethod();
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
}
