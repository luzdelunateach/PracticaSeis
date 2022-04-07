using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TestParalelims
{ //Read line detiene la tarea
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("You have 15 seconds to star this small Test Answer (y/n): ");
            String a = Console.ReadLine();
           
            if(a.Equals(""))
            {
                Console.WriteLine("Wrong, your answer should be y/n ");
            }
            else
            {
                switch (a)
                {
                    case "y":
                        var timeElapsed = await MainDos(); //await desemcapsula es tarea
                        Console.WriteLine($"Test is finish in: {timeElapsed / 100m} seconds");
                        break;
                        
                    case "n":
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;

                } 
            }
        }
        public static async Task<long> MainDos()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var task1 = Process1(); //await Process1(); aqui si importa el
            var task2 = Process2(); //await Process2();

            //var task1 = //WhenAny
            await Task.WhenAny(task1, task2); //respuestas de las ejecuciones en las lineas 33 y 34 - los dos se ejecutan al mismo tiempo y el hilo principal se detetiene
            stopwatch.Stop();
            Environment.Exit(0);
            return stopwatch.ElapsedMilliseconds;
        }

        public static async Task Process1() //task abre los hilos
        {
            await Task.Run(() =>
            {
            int good = 0;
            int wrong = 0;
            Console.WriteLine("You only have 15 sg");
            Console.WriteLine("What is the capital city of Mexico?\n a.CDMX\nb.Monterry\nc.Puebla");
            String res1 = Console.ReadLine();
            if (res1.Equals("a") || res1.Equals("A"))
            {
                good++;
            }
            else
            {
                wrong++;
            }
            Console.WriteLine("What is the capital of China?\na.Paris\nb.Pekin\nc.Mexico City");
            String res2 = Console.ReadLine();
            if (res1.Equals("b") || res1.Equals("B"))
            {
                good++;
            }
            else
            {
                wrong++;
            }
            Console.WriteLine("What is the capital of Argentina?\na.Basilia\nb.Rome\nc.Buenos Aires");
            String res3 = Console.ReadLine();
            if (res1.Equals("c") || res1.Equals("C"))
            {
                good++;
            }
            else
            {
                wrong++;
            }
            double points = 0.0;
            points = (good)/3;
            Console.WriteLine("Average: " + points);
            });
        }

        public static async Task Process2()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Time is over!!!");
            });
        }
    }
    
}
