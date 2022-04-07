using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace Reminder
{
    class Program
    {
        static void Main(string[] args)
        {
            startMenu();
        }
        static async Task startMenu()
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime dateValue;
            DateTime dateValue2;
            Console.WriteLine("What's your event name?");
            var evento = Console.ReadLine();
            if (String.IsNullOrEmpty(evento))
               Console.WriteLine("Error");
            else{
               Console.WriteLine("When will it start? (Please indicate the date with the next format: mm/dd/yyyy)");
               var date1 = Console.ReadLine();
               if (DateTime.TryParseExact(date1, "MM/dd/yyyy", enUS, DateTimeStyles.None, out dateValue))
               {
                    Console.WriteLine("Please indicate how many days will Star Reminder You");
                    string d = Console.ReadLine();
                    if (Int32.TryParse(d, out int days))
                    {
                        Console.WriteLine("Please indicate the current date.");
                        var date2 = Console.ReadLine();
                        if (DateTime.TryParseExact(date2, "MM/dd/yyyy", enUS, DateTimeStyles.None, out dateValue2))
                        {
                            if (dateValue2 >= dateValue)
                            {
                                Console.WriteLine("The current date can't be higher than the event date.");
                            }
                            else
                            {
                                Console.Clear();

                                DateTime currentDate = await Asynchronous.Reminder(dateValue, dateValue2, days);
                                await Asynchronous.EventDay(currentDate,dateValue);

                                Console.Clear();
                                Console.WriteLine($"Hey, {evento} is today!!!");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Please insert a valid date format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please insert an integer");
                    }
                }else
                {
                    Console.WriteLine("Please insert a valid date format.");
                    return;
                }
           }
           
        }
            
    }
    public class Asynchronous
    {
       
        public static async Task<DateTime> Reminder(DateTime date, DateTime date2, int days)
        {
           date = date.AddDays(-days);
           while (date2 < date)
            {
                Console.WriteLine(date2.ToString("MM/dd/yyyy"));
                //await Task.Delay(1000);
                Task.Delay(3000).Wait();
                date2 = date2.AddDays(1);
                Console.Clear();
            }
           return date2;
        }

        public static async Task<DateTime> EventDay(DateTime currentDate1, DateTime dateEvent)
        {
            while (currentDate1 < dateEvent )
            {
                Console.WriteLine($"Only {dateEvent.Day-currentDate1.Day} days to the event!");
                //await Task.Delay(TimeSpan.FromSeconds(3)); //Task.Delay(1000);TimeSpan.FromSeconds(1)
                Task.Delay(3000).Wait();
                currentDate1 = currentDate1.AddDays(1);
                Console.Clear();
            }
            return dateEvent;
        }
    }
}
