using System;
using System.Collections.Generic;
using System.Linq;
using Bussiness.Services.Implementations;
using Data.Entities;

namespace eShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var console = new eShopConsole();
            var showMenu = true;
            while (showMenu)
            {
                showMenu = console.MenuClienteAdministrador();
            }
        }
    }
}
