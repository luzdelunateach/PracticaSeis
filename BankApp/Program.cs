using System;
using BankApp;
//namespace la agrupacion virtuales de una clase. en muchas partes
//El assembling son archivos dll una vez que compilas el codigo, arma todo los paquetes. el resultado despues de la compilacion en un archivo

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account("Luna",1000,0);
            var giftCard = new GiftCardAccount("Ariadne", 5000);
            Console.WriteLine($"Se creo cuenta con numero {giftCard.Number} con un saldo de {giftCard.Balance} por el usuario {giftCard.Owner}");
            giftCard.Deposit(200, DateTime.Now.Date.AddDays(-4), "Para los tacos");
            giftCard.Deposit(500, DateTime.Now.Date.AddDays(-4), "Para la gasolina");
            giftCard.Withdraw(2000, DateTime.Now.Date.AddDays(0), "Pago de la colegiatura");

            Console.WriteLine(giftCard.getAccountHistory());
        }
    }
}
