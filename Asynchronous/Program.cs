using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    class Program
    {
        static async Task Main(string[] args)
        {
           
            //Console.WriteLine("Loading...");
            //Asynchronous.WaitForIt();
            //await Asynchronous.WaitForIt2(); //await es una promesa pero eventualmente voy a regresar ati con una promesa
            //async esperando al servidor mientras 
            var timeElapsed = await Parallelism.Main(); //await desemcapsula es tarea
            Console.WriteLine($"Ambos procesos finalizan despues {timeElapsed / 100m} seconds");
        }
        
    }
    public class Asynchronous
    {
        public static async Task WaitForIt()
        {
            await Task.Delay(TimeSpan.FromSeconds(5)); //await
            Console.WriteLine("Five seconds complete");
        }

        /*public static string Something()
        {

        }*/
        public static async Task WaitForIt2()
        {
            await Task.Delay(10000);
            Console.WriteLine("Ten secoinds complete");
        }
    }
    //Parelilismo
    public class Parallelism
    {
        public static async Task<long> Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var task1 = Process1(); //await Process1(); aqui si importa el
            var task2 = Process2(); //await Process2();
           
            //var task1 =
            await Task.WhenAll(task1, task2); //respuestas de las ejecuciones en las lineas 33 y 34 - los dos se ejecutan al mismo tiempo y el hilo principal se detetiene
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static async Task Process1() //task abre los hilos
        {
            await Task.Run(() =>
            {
                Thread.Sleep(4000);
            });
        }

        public static async Task Process2()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
        }

        //formato de la fecha no sea igual 
        //mostrar en consola el dia transcurrido
        //mostrar
    }
}
