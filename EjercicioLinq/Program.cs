using System;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] numbers = { 1, 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            // var squaredNumbers = numbers.Select(square);

            Console.WriteLine(String.Join(",", squaredNumbers));

            //los actions pueden también declararse sin variables de entrada
            Action line = () => Console.WriteLine("Hola");

            Func<int, int, string> IsTooLong = (x, y) => x > y ? "Es mayor" : "es menor"; //el ultimo es el tipo de dato que regresa

            /*if (x > y)
            {
                return "es mayor";
            }
            else
            {
                return "es menor";
            }*/

            //Tuplas es una clase compleja que puedan tener multiples propiedades

            //apartir de C# 7 
            var tuplas = MisTuplas();
            Console.WriteLine(tuplas.EsCorrecto+" Mensaje: "+tuplas.Item2);

            //podemos utilizar las tuplas en las funciones
            Func<int, int, (bool, string)> MiFunc = (x, y) => (x > y, "Mi mensaje");

            //Se pueden usar delegados con parametros descartados C#9
            Func<int, int, int> constant = (_,_) => 42; //parametros descartados
            Action<int, int> constant2 = (_, _) => Console.WriteLine(43);

            _ = IsTooLong;
            //Un action con serie de declaracines
            Action<int> miAccionAsincrona = miParametro =>
            {
                //Task.Deley(2000);
                Console.WriteLine("Me espere 200 milisegundos");
            };

            Console.WriteLine(IsTooLong(20, 15));
            Console.WriteLine(IsTooLong2(20, 15));

            //un Action con metodo asyncrono
            //Action<int> miotraAccionbAsubcrina = async parametro => await DelayConImpresion(parametro);
            Action<int> miotraAccionbAsubcrina = async parametro => await DelayConImpresion(parametro);
        }

        static async Task DelayConImpresion(int x)
        {
            Task.Delay(2000);
            Console.WriteLine("Me esperé 2000 milisegundos e imprimi" + x);
        }

        static(bool EsCorrecto,string Mensaje) MisTuplas()
        {
            return (true, "mensaje de prueba");
        }

        //metodo con cuerpo de expresion
        static string IsTooLong2(int x, int y) => x > y ? "es mayor" : "es menor";

        //en ves de
    }

    public class MiClase
    {
        public bool Resultado { get; set; }
        public string Mensaje { get; set; }
    }
}
