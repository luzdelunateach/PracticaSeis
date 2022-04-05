using System;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert the first number:");
            var input = Console.ReadLine();
            Console.WriteLine("Please insert the second number:");
            var inputY = Console.ReadLine();
            if (Double.TryParse(input, out double x)&& Double.TryParse(inputY, out double y)) //parseo de nuestra variable y validamos
            {
                Console.WriteLine("Delegate Calculator: ");
                DelegateCalculator.Operate(x, y); //si si entra envia el numero
                Console.WriteLine("------------------ ");
                Console.WriteLine("Fuction Calculator: ");
                FunctionCalculator.Lambda(x, y);
            }
            else
            {
                Console.WriteLine("Please insert a valid number.");
            }
            
        }
    }
    class DelegateCalculator
    {
        public delegate double SelfOperator(double x); //este delegado que va retornar un valor doble y recibe un parametro 
        public delegate double Operator(double x, double y);
      
        //la variable es un metodo como tal - no sabemos que 
        //mas de tres parametros NO, mejor has una funcion normal
        public static void Operate(double num, double num2)
        {
            SelfOperator square = new SelfOperator(x =>x * x); //Los delegados son para recibir metodos como parametro y que debe ser una sintaxis identica a quien los invoca
            Console.WriteLine($"The first square operation result in:{square(num)}\t The second square operation result is:{square(num2)}"); //x y num son lo mismo

            Operator addition = new Operator((x, y) => x + y);
            Console.WriteLine($"Addition equals to:{addition(num,num2)}"); //x y y, num num2 son los mismos solo cambia las varaibles para identificarlos

            Operator substraction = new Operator((x, y) => x - y);
            Console.WriteLine($"Substract equals to:{substraction(num, num2)}");

            Operator division = new Operator((x, y) => x / y);
            Console.WriteLine($"Division equals to:{division(num, num2)}");

            Operator exponentials = new Operator((x, y) => Math.Pow(x,y));
            Console.WriteLine($"Exponential equals to:{exponentials(num, num2)}");

            SelfOperator cos = new SelfOperator(x => Math.Cos(x));
            Console.WriteLine($"Cos equals to:{cos(num)}");

            SelfOperator sin = new SelfOperator(x => Math.Sin(x));
            Console.WriteLine($"Sin equals to:{sin(num)}");
        }
        

    }
    class FunctionCalculator
    {
        public static void Lambda(double x, double y)
        {
            Func<double, double, double> addition = (x, y) => x + y;
            Console.WriteLine($"Addition equals to:{addition(x, y)}");

            Func<double, double, double> substraction = (x, y) => x - y;
            Console.WriteLine($"Substract equals to:{substraction(x, y)}");

            Func<double, double, double> division = (x, y) => x / y;
            Console.WriteLine($"Division equals to:{division(x, y)}");

            Func<double, double, double> multiplication = (x, y) => x * y;
            Console.WriteLine($"Multiplication equals to:{multiplication(x, y)}");

            Func<double, double, double> exponentials = (x, y) => Math.Pow(x,y);
            Console.WriteLine($"Exponential equals to:{exponentials(x, y)}");

            Func<double, double> cos = (x) => Math.Cos(x);
            Console.WriteLine($"Cos equals to:{cos(x)}");

            Func<double, double> sin = (x) => Math.Sin(x);
            Console.WriteLine($"Sin equals to:{sin(x)}");
        }
        //Func<double, double, double> addition=(x, y) => x + y;
        //is the same as 2 parameters and the value of return
        /*static double Addition(double x, double y)
        {
            return x + y;
        }*/
    }
}
