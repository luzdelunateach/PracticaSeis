using System;

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var polygon = new Polygon(20,50); //Constructor por defecto Polygon
            //var polygon1 = new Polygon(20);
            var square = new Square(20, 20);
            polygon.Base = 50;
            Polygon.Show(); //usamos en el nombre de la clase siendo el metodo statico
            Console.WriteLine(polygon.Base);
        }
    }

    //this acceder a la instancia de la misma
    class Polygon
    {
        public decimal Base { get; set; }
        public decimal Height { get; set; }

        private decimal Base2;

        public Polygon(){} //PEQUEÑOS REFLEJOS DE ESTA AL ELOIMINAR EL CONSTRUCTOR VACIO, LAS NUEVAS INSTANCIAS NO TIENEN DE DONDE BASARSE SI NO LO PONEMOS

        public Polygon(decimal height, decimal baseDim) //Constructor lo recibe y se encarga de construir el objeto
        {
            Base = baseDim;
            Height = height;
        }
        //Puedo tener más de un constructor
       /* public Polygon(decimal heightFim)
        {
            Height = heightFim;
        }*/
        public void Set(decimal base2)
        {
            Base = base2;
        }
        public decimal Get()
        {
            return Base2;
        }
        //public abstract decimalGetArea() el hijo forzosamente debe tener un override .- Cuenta bancaria, un metodo va notificar - CLASE PADRE LOS HIJOS FORZOSAMENTE VAN AHACER UN OVERRIDE
        //public virtual decimal GetArea() yo bvoy a existir tengo mi logica pero si uno de mis hijos queire modificarlo lo hace - TENGO UN VIRTUAL EN MI PADRE PERO ES MI DECISION SE HAGO USO DE 
        //public abstract decimal GetArea() { }

        //public decimal GetArea()
        //{
        //return Base * Height;
        //}

        //PUBLIC CUALQUIERA EN LA APLICACION PUEDE ACCEDER
        //PRIVATE UNICAMENTE LA LOGICA DENTRO DE LA CLASE PUEDE ACCEDER
        //PROTECTED NADIE MAS QUE LOS HIJOS Y LA MISMA CLASE PUEDEN ACCEDER

        public virtual decimal GetArea()
        {
            return Base * Height / 2;
        }
        public static void Show()
        {

        }
    }
    //Clase statica
    class Square: Polygon
    {
        public Square(decimal height, decimal baseDim)
        {
            Base = baseDim;
            Height = height;
        }
    }
    class Rectangule : Polygon
    {
        public Rectangule(decimal height, decimal baseDim)
        {
            Base = baseDim;
            Height = height;
        }
    }

    class Triangle : Polygon
    {
        public Triangle(decimal height, decimal baseDim)
        {
            Base = baseDim;
            Height = height;
        }

        public override decimal GetArea()
        {
            return Base * Height /2;
        }
    }
}
