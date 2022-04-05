using System;

namespace GeometricCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select one item: 1.Square, 2.Triangle, 3.Rect, 4.Circle");
            var input = Console.ReadLine();
            if (Int32.TryParse(input, out int x))
            {
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Side");
                        var s  = Console.ReadLine();
                        if (Double.TryParse(s, out double si))
                        {
                            DelegateGeometricCalculator.SquareD(si);
                            FuctionGeometricCalculator.SquareF(si);
                        }
                        else
                        {
                            Console.WriteLine("Please insert a valid number.");
                        }
                        break;
                    case 2:

                        break;
                    case 3:
                        Console.WriteLine("Base");
                        var b = Console.ReadLine();
                        Console.WriteLine("Length");
                        var l = Console.ReadLine();
                        if(Double.TryParse(b, out double ba) && Double.TryParse(l, out double le))
                        {
                            DelegateGeometricCalculator.RectangleD(ba, le);
                            FuctionGeometricCalculator.RectangleF(ba, le);
                        }else
                        {
                            Console.WriteLine("Please insert a valid number.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ride");
                        var r = Console.ReadLine();
                        if (Double.TryParse(r, out double ra))
                        {
                            DelegateGeometricCalculator.CircleD(ra);
                            FuctionGeometricCalculator.CircleF(ra);
                        }
                        else
                        {
                            Console.WriteLine("Please insert a valid number.");
                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please insert a valid number.");
            }
        }
    }
    class DelegateGeometricCalculator
    {
        public delegate double Rectangle(double x, double y);
        public delegate double Square(double x);
        public delegate double Circle(double x);

        public static void RectangleD(double num, double num2)
        {
            Rectangle area = new Rectangle((b, l) => b * l);
            Console.WriteLine($"D. Area of Rectangle: {area(num,num2)}");

            Rectangle perimetro = new Rectangle((b, l) =>(2 * b) + (2 * l));
            Console.WriteLine($"D. Perimeter of Rectangle: {perimetro(num, num2)}");

        }

        public static void SquareD(double num)
        {
            Square areaS = new Square(s => s * s);
            Console.WriteLine($"D. Area of Square: {areaS(num)}");

            Square perimeterS = new Square(s => 4 * s);
            Console.WriteLine($"D. Perimeter of Square: {perimeterS(num)}");
        }

        public static void CircleD(double num)
        {
            Square areaC = new Square(c => Math.PI * Math.Pow(c,2));
            Console.WriteLine($"D. Area of Circle: {areaC(num)}");

            Square perimeterC = new Square(c => 2 * Math.PI * c);
            Console.WriteLine($"D. Perimeter of Circle: {perimeterC(num)}");
        }

    }

    class FuctionGeometricCalculator
    {
       public static void RectangleF(double x, double y)
        {
            Func<double, double, double> areaRectangle = (x, y) => x * y;
            Console.WriteLine($"F. Area of Rectangle: {areaRectangle(x, y)}");

            Func<double, double, double> perimeterRectangle = (x, y) => (2 * x) + (2 * y);
            Console.WriteLine($"F. Perimeter of Rectangle: {perimeterRectangle(x, y)}");

        }

        public static void SquareF(double x)
        {
            Func<double, double> areaSquare = (x) => x * x;
            Console.WriteLine($"F. Area of Square: {areaSquare(x)}");

            Func<double, double> perimeterSquare = (x) => 4 * x;
            Console.WriteLine($"F. Perimeter of Square: {perimeterSquare(x)}");
        }

        public static void CircleF(double x)
        {
            Func<double, double> areaCircle =  c => Math.PI * Math.Pow(c, 2);
            //Console.WriteLine($"F. Area of Square: {areaSquare(x)}");

            Func<double, double> perimeterSquare = (x) => 4 * x;
            Console.WriteLine($"F. Perimeter of Square: {perimeterSquare(x)}");
        }

    }
}
