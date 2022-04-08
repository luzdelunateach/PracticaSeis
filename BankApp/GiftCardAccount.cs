using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class GiftCardAccount : Account
    {
       
        public GiftCardAccount(string name, decimal initialBalance): base(name,initialBalance) //que vamos usar el mismo constructor padre //se basan en el mismo
        {
            
        }

       public string getAccountHistory()
        {
            decimal balance = 0;
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tBalance\tDescription\t");
            foreach(var transaction in TransactionList)
            {
                balance += transaction.Amount;
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Description}");
            }
            return report.ToString();
        }

        public string getPrintHistory()
        {
            string result = "";
            foreach (var transaction in TransactionList) { 
                result += transaction.ToString();
            }
            return result;
        }
        //nueva cuenta que se llame credito, que tenga un limite de credito, si nosotros sobrepasamos ese credito. Vamos a tener un fi por avernos pasado
        //Del dos porciento
    }
    //que nos muestre todas las transacciones realizadas por la cuenta
    //clase que hereda de la principal que tenga 
    //Gift card vamos a transcribir
    //vamos a empezar con herencia, vamos a desarrollar una clase que erede de caunt, debe tener un metodo que implica en la consola
    //todo e acount history
    //la firma de un metodo es su mismo retorno
    //para que tengan la misma firma deben regresar lo mismo, mismo orden, en otro consutructor
}
