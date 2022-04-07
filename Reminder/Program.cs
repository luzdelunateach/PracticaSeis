using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Reminder
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();

        }
        static void menu()
        {
   
           String dato = "";
           Console.WriteLine("What's your event name?");
           dato = Console.ReadLine();
           if (String.IsNullOrEmpty(dato))
               Console.WriteLine("Error");
           else{
               Console.WriteLine("When will it start? (Please indicate the date with the next format: mm/dd/yyyy)");
               var date = Console.ReadLine();
               Console.WriteLine("Please indicate how many days will Star Reminder You");
               string d = Console.ReadLine();
               if(Int32.TryParse(d, out int days))
                {
                    compareDates(date, days);
                }
               
           }
           
        }

        public static void compareDates(String date, int days)
        {
            DateTime dateI = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            DateTime dateF = dateI.AddDays(days);

            Console.WriteLine(dateF);
        }
            
    }
    public class Asynchronous
    {
        public static async Task WaitForIt()
        { 
            await Task.Delay(TimeSpan.FromSeconds(100000)); //await
            Console.WriteLine("Five seconds complete");
           
        }
    }
}
