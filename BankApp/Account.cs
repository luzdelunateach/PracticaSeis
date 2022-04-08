using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class Account
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach(var transaction in TransactionList)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }

        public List<Transaction> TransactionList { get; set; } = new List<Transaction> { };

        private readonly int _minimumBalance;
        private static int accountNumberSeed = 123456789; //si fuera nuestro seed

        public Account(string name, decimal initialBalance) : this(name,initialBalance,0){} //accede a la entidad y colocarle los valores

        public Account(string name, decimal initialBalance, int minimumBalance)
        {
            Owner = name;
            _minimumBalance = minimumBalance;
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            if (initialBalance > 0) //monto cuando abrimos una cuenta se deposita
                Deposit(initialBalance, DateTime.Now, "Balance inicial");
        }
        //un seed en la clase de mi contexto voy a exeder a otra clase seed en la primera ejecucuion del programa asignas datos para que la DB no este vacia
        //y asi la plicacion no truene
        //los seed se ejecuta en la primera corrida que se instala, cuando la instalas en un nuevo ambiente va a tomar todos los datos que haya y los va anexar
        public virtual void Deposit(decimal amount, DateTime date, string description)
        {
            if (amount < 0)
                Console.WriteLine("El deposito debe ser mayor a cero");

            var deposit = new Transaction(amount, date, description);
            TransactionList.Add(deposit);
        }

        public void Withdraw(decimal amount, DateTime date, string description) //Retiro como vamos a hacer eso
        {
            if (amount<0)
            {
                Console.WriteLine("");
            }
            var transaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance); //declaramos un balance minimo de la cuenta, si el usario 2,400, y tiene 900
            var withdrawal = new Transaction(amount, date, description);
            TransactionList.Add(withdrawal);
        }

       

        protected virtual Transaction CheckWithdrawalLimit(bool isOverCharge)
        {
            if (isOverCharge)
            {
                Console.WriteLine("No tienes fondos suficientes");
                throw new InvalidOperationException("No tienes fondos suficientes."); //La alternativa del bloque de codigo
            }
            else
            {
                return default; //quiere decir que nos regresa el valor por defecto de la variable de retorno, cada variable tiene un valor por defecto pero nunca asignas el valor defecto.
                //regresamos la transaccion en esi
            }
        }

        //arriba de un balance se aumenta el 5$
    }

}
    
