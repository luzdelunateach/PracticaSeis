using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    //utilizar el minomo requerido si yo sobre paso eso, me va a pedir una multa sobre giro.
    //la consola despliega una, debe ser una sub clase de account
    //por cada peso que te pases
    //que nos presta mil pesos si la podemos depositar, en el momento en el que yo la use y sobre pase el creditosobre cargo por manejo de cuenta
    //metodo fin de mes: tomar el resido de lo que nos pasamos y va a calcular el fin de mes - fecha de corte
    //cobrar el 7%
    class CreditAccount : Account
    {
        public CreditAccount(string name, decimal initialBalance, int creditLimit):base(name, initialBalance, -creditLimit)
        {

        }
        public void PerformEndMountTransaction(int solicitado, int creditLimit, decimal initialBalance)
        {
            if(Balance < 0)
            {
                var interest = -Balance * 0.07m;
                Withdraw(interest, DateTime.Now, "Cargo de interes mensual");
            }
        }

        public void PerformInvertion(int solicitado, int creditLimit, decimal initialBalance)
        {
            if (Balance > 500)
            {
                var intereinvertiont = Balance * 0.05m;
                //Deposit(aumout, DateTime.Now, "Cargo de interes mensual");
            }
        }
        protected override Transaction CheckWithdrawalLimit(bool isOverCharge) => isOverCharge?new Transaction(-20, DateTime.Now,"Cargo por sobregiro") :default;

        // solo que con el de inversion vamos a estar registrando depositos, y cuando llegue la fecha del corte
        //Paola Gonzalez: por cada peso que haya en el balance o que se haya depositado le vas a regresar al usuario el 5% extra del total del balance

        


    }
}
