using Model;
using System;
using System.Threading.Tasks;

namespace EFeShop
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    await AppDbContextSeed.SeedAsync(context);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var menu = new Menu();
            var showMenu = true;
            while (showMenu)
            {
                showMenu = menu.Show();
            }
        }
    }
}
