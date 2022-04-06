using System;

namespace WorkingWithDates
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Now.Date;
            var x = date.ToString("dd/mm/yyyy"); //El formato que yo dese manejar en mi base de datos, para hacer comparaciones, aveces es necesario tener un mismo formato
            //para evitar problemas con la comparacion

            Console.WriteLine(x);
        }
    }
}
